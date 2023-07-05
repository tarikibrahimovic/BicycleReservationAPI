using BicycleReservation.Domain.DTO.Manager;
using BicycleReservation.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleReservation.Domain.Resources.Queries
{
    public class GetStationStatisticsQueryHandler : IRequestHandler<GetStationStatisticsQuery, StationStatisticsResponse>
    {
        private readonly IUnitOfWork uow;

        public GetStationStatisticsQueryHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<StationStatisticsResponse> Handle(GetStationStatisticsQuery request, CancellationToken cancellationToken)
        {
            var response = await uow.ManagerRepository.GetStationStatistics(request.Id);
            return response;
        }
    }
}
