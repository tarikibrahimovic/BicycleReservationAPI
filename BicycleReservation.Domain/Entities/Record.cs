using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleReservation.Domain.Entities
{
    public class Record
    {
        [Key]
        public int Id { get; set; }
        public string BicycleId { get; set; }
        public Bicycle Bicycle { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime StartDate { get; set; }
        public int? NumberOfHours { get; set; }
        public float? CostPerHour { get; set; }
        public int? StartStationId { get; set; }
        public Station StartStation { get; set; }
        public int? EndStationId { get; set; }
        public Station EndStation { get; set; }
    }
}
