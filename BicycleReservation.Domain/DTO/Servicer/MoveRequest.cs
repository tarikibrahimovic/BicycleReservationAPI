using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleReservation.Domain.DTO.Servicer
{
    public class MoveRequest
    {
        public IEnumerable<string> BicycleIds { get; set; }
        public int StationId { get; set; }
    }
}
