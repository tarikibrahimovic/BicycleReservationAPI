using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleReservation.Domain.DTO.Manager
{
    public class OverallStatisticsResponse
    {
        public int NumberOfStations { get; set; }
        public int NumberOfBicycles { get; set; }
        public int NumberOfRents { get; set; }
        public int HoursRented { get; set; }
        public double CreditsSpent { get; set; }
    }
}
