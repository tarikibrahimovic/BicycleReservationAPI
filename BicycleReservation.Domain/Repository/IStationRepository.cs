using BicycleReservation.Domain.DTO.Client;
using BicycleReservation.Domain.DTO.Station;
using BicycleReservation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleReservation.Domain.Repository
{
    public interface IStationRepository : IGenericRepository<Station, int>
    {
        public Task<List<Station>> GetAll();
        public Task<StationResponse> GetStation(int id, BicycleType? bicycleType = null, int? pageNumber = null, int? pageSize = null);
    }
}
