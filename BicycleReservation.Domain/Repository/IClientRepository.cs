using BicycleReservation.Domain.DTO.Client;
using BicycleReservation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleReservation.Domain.Repository
{
    public interface IClientRepository : IGenericRepository<User, int>
    {
        public Task<BicycleRentResponse> RentBicycle(BicycleRentRequest request);
        public Task<ReturnBicycleResponse> ReturnBicycle(ReturnBicycleRequest request);
    }
}
