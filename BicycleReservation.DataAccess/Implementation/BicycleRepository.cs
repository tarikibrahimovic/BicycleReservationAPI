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
    public class BicycleRepository : GenericRepository<Bicycle, string>, IBicycleRepository
    {
        public BicycleRepository(DataContext context) : base(context)
        {
                
        }

    }
}
