using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleReservation.Domain.DTO.Manager
{
    public class OverallStatisticsResponse
    {
        public int Stations { get; set; }
        public int Bicycles { get; set; }
        public int Rents { get; set; }
        public int HoursRented { get; set; }
        public double CreditsSpent { get; set; }
    }
}
