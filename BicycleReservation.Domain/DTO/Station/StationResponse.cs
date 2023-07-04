using BicycleReservation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleReservation.Domain.DTO.Station
{
    public class StationResponse
    {
        public List<Bicycle> Bicycles { get; set; }
        public BicycleReservation.Domain.Entities.Station Station { get; set; }
        public bool HasRentedBike { get; set; } = false;
    }
}
