using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleReservation.Domain.DTO.Manager
{
    public class BicycleStatisticsResponse
    {
        public int NumberOfRents { get; set; }
        public int HoursRented { get; set; }
        public double CreditsSpent { get; set; }
        public int TimesServiced { get; set; }
        public int TimesRepaired { get; set; }
    }
}
