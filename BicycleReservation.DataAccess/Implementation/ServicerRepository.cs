using BicycleReservation.DataAccess.Context;
using BicycleReservation.Domain.DTO.Servicer;
using BicycleReservation.Domain.Entities;
using BicycleReservation.Domain.Repository;
using BicycleReservation.Domain.Resources.Commands.Create;
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
    public class ServicerRepository : GenericRepository<User, int>, IServicerRepository
    {
        public IHttpContextAccessor acc { get; set; }
        public ServicerRepository(DataContext context, IHttpContextAccessor acc) : base(context)
        {
            this.acc = acc;
        }

        public async Task<bool> ResolveBreakdown(ResolveRequest request)
        {
            var breakdown = await context.Breakdowns.FirstOrDefaultAsync(x => x.Id == request.BreakdownId);
            if (breakdown == null)
                throw new Exception("Breakdown does not exist");
            breakdown.ResolvedDate = DateTime.UtcNow;
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<List<BreakdownsResponse>> GetBreakdowns()
        {
            var records = context.Records.Include(r => r.Bicycle).ThenInclude(x => x.Breakdowns).Include(r => r.EndStation).Join(context.Bicycles, r => r.BicycleId, b => b.Id, (r, b) => new { r, b })
                .GroupBy(x => x.r.BicycleId)
                .Select(x => x.OrderByDescending(y => y.r.StartDate).Select(x => x.r).FirstOrDefault())
                .ToList();
            var bicycles = await Task.Run(() => records.Where(x => x.EndStationId != null && x.Bicycle.Breakdowns.Any(b => b.ResolvedDate != null)).Select(x => new
            {
                x.Bicycle,
                Station = x.EndStation,
            }).ToList());

            List<BreakdownsResponse> breakdowns = new();
            var stations = await Task.Run(() => context.Stations.ToList());

            for (int i = 0; i < stations.Count; i++)
            {
                var array = new List<Bicycle>();
                for (int j = 0; j < bicycles.Count; j++)
                {
                    if (stations[i].Id == bicycles[j].Station.Id)
                    {
                        array.Add(bicycles[j].Bicycle); 
                    }
                }
                BreakdownsResponse response = new BreakdownsResponse
                {
                    Station = stations[i],
                    Bicycles = array
                };
                breakdowns.Add(response);
            }

            return breakdowns;

        }

        public async Task<bool> Move(MoveRequest request)
        {
            int userId = int.Parse(acc.HttpContext.User.FindFirst(ClaimTypes.PrimarySid).Value);
            var bicycles = await context.Bicycles.Where(x => request.BicycleIds.Contains(x.Id)).ToListAsync();
            if (bicycles.Count != request.BicycleIds.Count())
                throw new Exception("Some bicycles do not exist");
            foreach (var bicycle in bicycles)
            {
                var record = new Record
                {
                    BicycleId = bicycle.Id,
                    UserId = userId,
                    StartDate = DateTime.UtcNow,
                    NumberOfHours = null,
                    CostPerHour = null,
                    StartStationId = request.StationId,
                    EndStationId = request.StationId
                };
                await context.Records.AddAsync(record);
            }
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<Service> ServiceBicycle(ServiceBicycleCommand request)
        {
            var bicycle = await context.Bicycles.FirstOrDefaultAsync(x => x.Id == request.BicycleId) ?? throw new Exception("Bicycle does not exist");
            var service = new Service
            {
                BicycleId = request.BicycleId,
                UserId = request.UserId,
                ServiceDate = DateTime.UtcNow
            };
            await context.Services.AddAsync(service);
            await context.SaveChangesAsync();
            return service;
        }

        public async Task<List<BicycleWithService>> GetBicyclesWithServices()
        {
            // Returns all bicycles ordered by the date of the last service. Returns them with all the services
            var bicycles = await context.Bicycles.Include(x => x.Services).OrderByDescending(x => x.Services.Max(x => x.ServiceDate)).Select(x => new BicycleWithService()
            {
                Bicycle = x,
                ServiceDate = x.Services.Max(x => x.ServiceDate)
            }).ToListAsync();
            return bicycles;
        }
    }
}
