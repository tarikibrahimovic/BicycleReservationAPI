using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleReservation.Domain.DTO.Manager
{
    public class StationStatisticsResponse
    {
        public int Arrivals { get; set; }
        public int Departures { get; set; }
        public int Bicycles { get; set; }
        public int Breakdowns { get; set; }
    }
}
