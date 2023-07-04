using BicycleReservation.Domain.DTO.Servicer;
using BicycleReservation.Domain.Entities;
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
    }
}
