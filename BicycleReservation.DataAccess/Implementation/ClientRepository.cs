using BicycleReservation.DataAccess.Context;
using BicycleReservation.Domain.DTO.Client;
using BicycleReservation.Domain.Entities;
using BicycleReservation.Domain.Repository;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BicycleReservation.DataAccess.Implementation
{
    public class ClientRepository : GenericRepository<User, int>, IClientRepository
    {
        private readonly IHttpContextAccessor acc;
        public ClientRepository(DataContext context, IHttpContextAccessor acc) : base(context)
        {
            this.acc = acc;
        }
        public async Task<BicycleRentResponse> RentBicycle(BicycleRentRequest request)
        {
            int userId = int.Parse(acc.HttpContext.User.FindFirst(ClaimTypes.PrimarySid).Value);
            if(context.Records.Any(r => r.UserId == userId && r.EndStationId == null))
                throw new Exception("You already have a bicycle rented");
            
            var bicycle = context.Bicycles.FirstOrDefault(b => b.Id == request.BicycleId);
            if(bicycle == null)
                throw new Exception("Bicycle not found");

            if(context.Records.Any(r => r.BicycleId == request.BicycleId && r.EndStationId == null))
                throw new Exception("Bicycle is already rented");

            var lastBicycleRecord = context.Records.Where(r => r.BicycleId == request.BicycleId).OrderByDescending(r => r.StartDate).FirstOrDefault();

            var costPerHour = 5D;

            var creditsUsed = costPerHour * request.NumberOfHours;
            var userCredits = context.Credits.FirstOrDefault(c => c.UserId == userId) ?? throw new Exception("User credits not found");
            if (userCredits.Credits < creditsUsed)
                throw new Exception("Not enough credits");

            userCredits.Credits -= creditsUsed;

            var record = new Record
            {
                BicycleId = request.BicycleId,
                UserId = userId,
                StartDate = DateTime.Now,
                NumberOfHours = request.NumberOfHours,
                CostPerHour = costPerHour,
                StartStationId = lastBicycleRecord.EndStationId,
            };

            await context.Records.AddAsync(record);
            await context.SaveChangesAsync();

            return new BicycleRentResponse
            {
                LockCode = bicycle.LockCode,
                Cost = creditsUsed,
                Balance = userCredits.Credits,
            };
        }

        public async Task<ReturnBicycleResponse> ReturnBicycle(ReturnBicycleRequest request)
        {
            int userId = int.Parse(acc.HttpContext.User.FindFirst(ClaimTypes.PrimarySid).Value);

            var record = context.Records.FirstOrDefault(r => r.UserId == userId && r.EndStationId == null);
            if (record == null)
                throw new Exception("You don't have a bicycle rented");

            var station = context.Stations.FirstOrDefault(s => s.Id == request.StationId) ?? throw new Exception("Station not found");
            record.EndStationId = station.Id;

            return new ReturnBicycleResponse
            {
                Message = "Bicycle returned successfully",
            };
        }
    }
}
