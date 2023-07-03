using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleReservation.Domain.DTO.Client
{
    public class BicycleRentRequest
    {
        public string BicycleId { get; set; }
        public int NumberOfHours { get; set; }
    }
}
