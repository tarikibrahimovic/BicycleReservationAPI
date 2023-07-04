using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleReservation.Domain.Entities
{
    public class Breakdown
    {
        public int Id { get; set; }
        public int BicycleId { get; set; }
        public Bicycle Bicycle { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime? ResolvedDate { get; set; }
    }
}
