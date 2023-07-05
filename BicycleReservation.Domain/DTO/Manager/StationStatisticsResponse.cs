using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleReservation.Domain.DTO.Manager
{
    public class StationStatisticsResponse
    {
        public int NumberOfArrivals { get; set; }
        public int NumberOfDepartures { get; set; }
        public int NumberOfBicycles { get; set; }
        public int NumberOfBreakdowns { get; set; }
    }
}
