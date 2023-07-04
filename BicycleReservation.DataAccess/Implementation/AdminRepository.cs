using BicycleReservation.DataAccess.Context;
using BicycleReservation.Domain.DTO.Admin;
using BicycleReservation.Domain.DTO.Auth;
using BicycleReservation.Domain.DTO.User;
using BicycleReservation.Domain.Entities;
using BicycleReservation.Domain.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BicycleReservation.DataAccess.Implementation
{
    public class AdminRepository : GenericRepository<User, int>, IAdminRepository
    {
        private readonly IHttpContextAccessor _acc;
        public AdminRepository(DataContext context, IHttpContextAccessor acc) : base(context)
        {
            _acc = acc;
        }

        public async Task<List<UserDTO>> GetAllUsers()
        {
            try
            {
                var users = context.Users.Include(u => u.Credits).Select(x => new UserDTO
                {
                    Id = x.Id,
                    Username = x.Username,
                    Email = x.Email,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    ImageUrl = x.ImageUrl,
                    Credits = x.Credits.Credits,
                    Role = x.Role,
                    Verified = x.VerificationToken != null ? false : true
                }).ToList();

                return users;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Bicycle> AddBicycle(int stationId, AddBicycleRequest request)
        {
            int userId = int.Parse(_acc.HttpContext.User.FindFirst(ClaimTypes.PrimarySid).Value);
            var stationExists = context.Stations.Any(x => x.Id == stationId);
            if (!stationExists)
                throw new Exception("Station does not exist");
            var bicycleExists = context.Bicycles.Any(x => x.Id == request.Id);
            if (bicycleExists)
                throw new Exception("Bicycle ID already exists");


            var lockCode = "";
            var random = new Random();
            for (int i = 0; i < 6; i++)
            {
                lockCode += random.Next(0, 9).ToString();
            }

            var bicycle = new Bicycle
            {
                Id = request.Id,
                Naziv = request.Naziv,
                LockCode = lockCode,
                Type = request.Type
            };

            var record = new Record
            {
                BicycleId = request.Id,
                UserId = userId,
                StartDate = DateTime.UtcNow,
                NumberOfHours = null,
                CostPerHour = null,
                StartStationId = stationId,
                EndStationId = stationId
            };

            await context.Bicycles.AddAsync(bicycle);
            await context.Records.AddAsync(record);
            await context.SaveChangesAsync();
            return bicycle;
        }

        public async Task<Station> AddStation(AddStationRequest request)
        {
            var station = new Station
            {
                Name = request.Name,
                Lat = request.Lat,
                Lng = request.Lng
            };

            await context.Stations.AddAsync(station);
            await context.SaveChangesAsync();
            return station;
        }
        public async Task<bool> DeleteUser(int id)
        {
            try
            {
                var user = await context.Users.FirstOrDefaultAsync(x => x.Id == id && x.IsActive == true);
                if (user == null)
                    throw new Exception("User does not exist!");
                if (user.Role == Role.Admin)
                    throw new Exception("Cannot delete admin user!");
                user.IsActive = false;
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> PromoteUser(PromoteRequest request)
        {
            try
            {
                User user = await context.Users.FirstOrDefaultAsync(x => x.Id == request.UserId && x.IsActive == true);
                if(user == null)
                    throw new Exception("User does not exist!");
                if(user.Role == Role.Admin)
                    throw new Exception("User is already admin!");
                if(request.Role == user.Role)
                {
                    throw new Exception("User is already that role!");
                }
                if(user.Role == Role.Client)
                {
                    var credits = await context.Credits.FirstOrDefaultAsync(x => x.UserId == user.Id);
                    context.Credits.Remove(credits);
                    user.Credits = null;
                }
                user.Role = request.Role;
                if(request.Role == Role.Client)
                {
                    var credits = new UserCredits
                    {
                        UserId = user.Id,
                        Credits = 100
                    };
                    await context.Credits.AddAsync(credits);
                    user.Credits = credits;
                }
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
