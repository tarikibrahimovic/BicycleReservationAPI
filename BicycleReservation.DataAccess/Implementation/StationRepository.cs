using BicycleReservation.DataAccess.Context;
using BicycleReservation.Domain.DTO.Client;
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

        public async Task<StationResponse> GetStation(int id, BicycleType? bicycleType = null, int? pageNumber = null, int? pageSize = null)
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

            if(bicycleType != null)
                bicycles = bicycles.Where(x => x.Type == bicycleType).ToList();

            var length = bicycles.Count;
            var numberOfPages = 0;

            if(pageNumber != null && pageSize != null)
            {
                bicycles = bicycles.Skip((int)pageNumber * (int)pageSize).Take((int)pageSize).ToList();
                numberOfPages = (int)Math.Ceiling((double)length / (int)pageSize);
            }
                

            var response = new StationResponse
            {
                Station = station,
                Bicycles = bicycles,
                Length = length,
                Pages = numberOfPages
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
