using BicycleReservation.DataAccess.Context;
using BicycleReservation.Domain.DTO.Client;
using BicycleReservation.Domain.Entities;
using BicycleReservation.Domain.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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
            if(request.NumberOfHours < 1 || request.NumberOfHours > 24)
                throw new Exception("Invalid number of hours");

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

            var bicycle = context.Bicycles.FirstOrDefault(b => b.Id == record.BicycleId);
            var newLockCode = "";
            for (int i = 0; i < 6; i++)
                newLockCode += new Random().Next(0, 10);
            bicycle.LockCode = newLockCode;

            await context.SaveChangesAsync();

            return new ReturnBicycleResponse
            {
                Message = "Bicycle returned successfully",
            };
        }

        public async Task<List<Record>> GetRents()
        {
            int userId = int.Parse(acc.HttpContext.User.FindFirst(ClaimTypes.PrimarySid).Value);
            return await context.Records.Include(r => r.Bicycle).Include(r => r.StartStation).Include(r => r.EndStation).Where(r => r.UserId == userId).OrderByDescending(r => r.StartDate).ToListAsync();
        }


        public async Task<bool> BreakdownReport(BicycleBreakdownRequest request)
        {
            var breakdown = await context.Breakdowns.FirstOrDefaultAsync(x => x.BicycleId == request.BicycleId && x.ResolvedDate == null);
            if (breakdown != null)
            {
                throw new Exception("Breakdown already reported");
            }
            var bicycle = await context.Bicycles.FirstOrDefaultAsync(x => x.Id == request.BicycleId);
            Breakdown breakdown1 = new Breakdown
            {
                Bicycle = bicycle,
                Description = request.Description,
                Date = DateTime.UtcNow
            };
            await context.Breakdowns.AddAsync(breakdown1);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
