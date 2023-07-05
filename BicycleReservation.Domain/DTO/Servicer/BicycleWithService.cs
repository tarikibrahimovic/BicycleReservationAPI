using BicycleReservation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleReservation.Domain.DTO.Servicer
{
    public class BicycleWithService
    {
        public Bicycle Bicycle { get; set; }
        public DateTime? ServiceDate { get; set; }
    }
}
