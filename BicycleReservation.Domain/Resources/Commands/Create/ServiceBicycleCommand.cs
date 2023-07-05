using BicycleReservation.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleReservation.Domain.Resources.Commands.Create
{
    public class ServiceBicycleCommand : IRequest<Service>
    {
        public string BicycleId { get; set; }
        public int UserId { get; set; }
    }
}
