using BicycleReservation.DataAccess.Context;
using BicycleReservation.Domain.DTO.Station;
using BicycleReservation.Domain.Entities;
using BicycleReservation.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleReservation.DataAccess.Implementation
{
    public class StationRepository : GenericRepository<Station, int>, IStationRepository
    {
        public StationRepository(DataContext context) : base(context)
        {
        }

        public async Task<List<Station>> GetAll()
        {
            return await Task.Run(() => context.Stations.ToList());
        }

        public async Task<StationResponse> GetStation(int id)
        {
            var station = await Task.Run(() => context.Stations.FirstOrDefault(x => x.Id == id)) ?? throw new Exception("Station does not exist");

            // Join record i bicycle tabele prema id bicikla, svaku grupu sortiraj prema StartDate i uzmi prvi record
            //var records = await Task.Run(() => from r in context.Records
            //                                   join b in context.Bicycles on r.BicycleId equals b.Id
            //                                   group r by r.BicycleId into g
            //                                   select g.OrderByDescending(x => x.StartDate).FirstOrDefault());


            var records = context.Records.Include(r => r.Bicycle).Join(context.Bicycles, r => r.BicycleId, b => b.Id, (r, b) => new { r, b })
                .GroupBy(x => x.r.BicycleId)
                .Select(x => x.OrderByDescending(y => y.r.StartDate).Select(x => x.r).FirstOrDefault())
                .ToList();

            List<Bicycle> bicycles = new();
            if(records != null)
                bicycles = await Task.Run(() => records.Where(x => x.EndStationId == id).Select(x => x.Bicycle).ToList());

            return new StationResponse
            {
                Station = station,
                Bicycles = bicycles
            };
        }
    }
}
