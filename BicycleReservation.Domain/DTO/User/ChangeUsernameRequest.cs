using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleReservation.Domain.DTO.User
{
    public class ChangeUsernameRequest
    {
        public string Username { get; set; } = string.Empty;
    }
}
