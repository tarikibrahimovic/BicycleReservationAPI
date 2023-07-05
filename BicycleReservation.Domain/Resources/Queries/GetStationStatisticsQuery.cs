using BicycleReservation.Domain.DTO.Manager;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleReservation.Domain.Resources.Queries
{
    public class GetStationStatisticsQuery : IRequest<StationStatisticsResponse>
    {
        public int Id { get; set; }
    }
}
