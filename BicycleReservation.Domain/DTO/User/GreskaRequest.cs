﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleReservation.Domain.DTO.User
{
    public class GreskaRequest
    {
        public string BicycleId { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
