using BicycleReservation.Domain.DTO.Servicer;
using BicycleReservation.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleReservation.Domain.Resources.Queries
{
    public class GetBicyclesWithServicesQuery: IRequest<List<BicycleWithService>>
    {
        
    }
}
