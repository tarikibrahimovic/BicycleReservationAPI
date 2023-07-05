using BicycleReservation.Domain.DTO.Servicer;
using BicycleReservation.Domain.Entities;
using BicycleReservation.Domain.Resources.Commands.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleReservation.Domain.Repository
{
    public interface IServicerRepository : IGenericRepository<User, int>
    {
        public Task<bool> ResolveBreakdown(ResolveRequest request);
        public Task<List<BreakdownsResponse>> GetBreakdowns();
        public Task<bool> Move(MoveRequest request);
        public Task<Service> ServiceBicycle(ServiceBicycleCommand request);
        public Task<List<BicycleWithService>> GetBicyclesWithServices();
    }
}
