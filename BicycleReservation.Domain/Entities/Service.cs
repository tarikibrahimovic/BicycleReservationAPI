using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleReservation.Domain.Entities
{
    public class Service
    {
        [Key]
        public int Id { get; set; }
        public string BicycleId { get; set; }
        public Bicycle Bicycle { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime ServiceDate { get; set; }
    }
}
