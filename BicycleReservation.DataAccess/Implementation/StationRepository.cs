using BicycleReservation.DataAccess.Context;
using BicycleReservation.Domain.DTO.Station;
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

        public async Task<List<Station>> GetAll()
        {
            return await Task.Run(() => context.Stations.ToList());
        }

        public async Task<StationResponse> GetStation(int id)
        {
            var station = await Task.Run(() => context.Stations.FirstOrDefault(x => x.Id == id)) ?? throw new Exception("Station does not exist");

            var records = context.Records.Include(r => r.Bicycle).Join(context.Bicycles, r => r.BicycleId, b => b.Id, (r, b) => new { r, b })
                .GroupBy(x => x.r.BicycleId)
                .Select(x => x.OrderByDescending(y => y.r.StartDate).Select(x => x.r).FirstOrDefault())
                .ToList();

            List<Bicycle> bicycles = new();
            if(records != null)
                bicycles = await Task.Run(() => records.Where(x => x.EndStationId == id).Select(x => x.Bicycle).ToList());


            string? userRole = _acc.HttpContext?.User?.FindFirst(ClaimTypes.Role)?.Value;

            if(userRole == null || (userRole != Role.Admin.ToString() && userRole != Role.Servicer.ToString()))
                bicycles.ForEach(x => x.LockCode = "");

            var rl = Role.Admin.ToString();

            return new StationResponse
            {
                Station = station,
                Bicycles = bicycles
            };
        }
    }
}
