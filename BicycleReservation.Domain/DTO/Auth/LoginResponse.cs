using BicycleReservation.Domain.DTO.User;
using BicycleReservation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BicycleReservation.Domain.DTO.Auth
{
    public class LoginResponse
    {
        public string Token { get; set; } = string.Empty;
        public UserDTO User { get; set; }
    }
}
