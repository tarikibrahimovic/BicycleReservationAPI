using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleReservation.Domain.DTO.Client
{
    public class BicycleRentResponse
    {
        public string LockCode { get; set; }
        public double Cost { get; set; }
        public double Balance { get; set; }
    }
}
