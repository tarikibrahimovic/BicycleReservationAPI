using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleReservation.Domain.Entities
{
    public enum BicycleType
    {
        Mountain,
        Road,
        City,
        Electric
    }

    public class Bicycle
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string LockCode { get; set; }
        public BicycleType Type { get; set; }
        public IEnumerable<Breakdown>? Breakdowns { get; set; }
        public IEnumerable<Record>? Records { get; set; }
        public IEnumerable<Service>? Services { get; set; } = new List<Service>();
    }
}
