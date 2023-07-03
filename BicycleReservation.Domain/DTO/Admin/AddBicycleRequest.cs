using BicycleReservation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleReservation.Domain.DTO.Admin
{
    public class AddBicycleRequest
    {
        public string Id { get; set; }
        public string Naziv { get; set; }
        public BicycleType Type { get; set; }
    }
}
