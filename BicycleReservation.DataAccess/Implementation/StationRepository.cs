using BicycleReservation.DataAccess.Context;
using BicycleReservation.Domain.DTO.Station;
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
using System.Threading.Tasks;

namespace BicycleReservation.DataAccess.Implementation
{
    public class StationRepository : GenericRepository<Station, int>, IStationRepository
    {
        private readonly IHttpContextAccessor _acc;
        public StationRepository(DataContext context, IHttpContextAccessor acc) : base(context)
        {
            _acc = acc;
        }

        public async Task<bool> PrijavaGreske(GreskaRequest request)
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

        public async Task<List<Station>> GetAll()
        {
            return await Task.Run(() => context.Stations.ToList());
        }

        public async Task<StationResponse> GetStation(int id)
        {
            var converted = int.TryParse(_acc?.HttpContext?.User?.FindFirst(ClaimTypes.PrimarySid)?.Value, out int userId);
            var station = await Task.Run(() => context.Stations.FirstOrDefault(x => x.Id == id)) ?? throw new Exception("Station does not exist");

            var records = context.Records.Include(r => r.Bicycle).ThenInclude(b => b.Breakdowns).Join(context.Bicycles, r => r.BicycleId, b => b.Id, (r, b) => new { r, b })
                .GroupBy(x => x.r.BicycleId)
                .Select(x => x.OrderByDescending(y => y.r.StartDate).Select(x => x.r).FirstOrDefault())
                .ToList();

            List<Bicycle> bicycles = new();
            if(records != null)
                bicycles = await Task.Run(() => records.Where(x => x.EndStationId == id && !x.Bicycle.Breakdowns.Any(b => b.ResolvedDate == null)).Select(x => x.Bicycle).ToList());


            string? userRole = _acc?.HttpContext?.User?.FindFirst(ClaimTypes.Role)?.Value;

            if(userRole == null || (userRole != Role.Admin.ToString() && userRole != Role.Servicer.ToString()))
                bicycles.ForEach(x => x.LockCode = "");

            var response = new StationResponse
            {
                Station = station,
                Bicycles = bicycles
            };

            if(converted)
            {
                var hasRentedBike = context.Records.Any(x => x.UserId == userId && x.EndStationId == null);
                response.HasRentedBike = hasRentedBike;
            }

            return response;
        }
    }
}
