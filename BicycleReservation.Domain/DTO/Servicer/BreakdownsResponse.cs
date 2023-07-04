using BicycleReservation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleReservation.Domain.DTO.Servicer
{
    public class BreakdownsResponse
    {
        public BicycleReservation.Domain.Entities.Station Station { get; set; }
        public IEnumerable<Bicycle> Bicycles { get; set; }

    }
}
