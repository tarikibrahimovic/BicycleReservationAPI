using BicycleReservation.Domain.DTO.Admin;
using BicycleReservation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleReservation.Domain.Repository
{
    public interface IAdminRepository : IGenericRepository<User, int>
    {
        public Task<StationDTO> AddStation(AddStationRequest request);
        public Task<Bicycle> AddBicycle(int stationId, AddBicycleRequest request);
    }
}
