using BicycleReservation.DataAccess.Context;
using BicycleReservation.Domain.DTO.Admin;
using BicycleReservation.Domain.Entities;
using BicycleReservation.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleReservation.DataAccess.Implementation
{
    public class AdminRepository : GenericRepository<User, int>, IAdminRepository
    {
        public AdminRepository(DataContext context) : base(context)
        {
        }

        public async Task<Bicycle> AddBicycle(int stationId, AddBicycleRequest request)
        {
            var stationExists = context.Stations.Any(x => x.Id == stationId);
            if (!stationExists)
                throw new Exception("Station does not exist");
            var bicycleExists = context.Bicycles.Any(x => x.Id == request.Id);
            if (bicycleExists)
                throw new Exception("Bicycle already exists");

            var bicycle = new Bicycle
            {
                Id = request.Id,
                LockCode = request.LockCode,
                Type = request.Type,
                StationId = stationId
            };

            await context.Bicycles.AddAsync(bicycle);
            await context.SaveChangesAsync();
            return bicycle;
        }

        public async Task<StationDTO> AddStation(AddStationRequest request)
        {
            var station = new Station
            {
                Name = request.Name,
                Lat = request.Lat,
                Lng = request.Lng
            };

            await context.Stations.AddAsync(station);
            await context.SaveChangesAsync();
            return new StationDTO
            {
                Name = station.Name,
                Lat = station.Lat,
                Lng = station.Lng
            };
        }
    }
}
