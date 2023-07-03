using BicycleReservation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleReservation.Domain.DTO.Admin
{
    public class PromoteRequest
    {
        public int UserId { get; set; }
        public Role Role { get; set; }
    }
}
