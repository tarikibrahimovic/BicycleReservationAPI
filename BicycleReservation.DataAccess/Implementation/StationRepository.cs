using BicycleReservation.DataAccess.Context;
using BicycleReservation.Domain.Entities;
using BicycleReservation.Domain.Repository;
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
    }
}
