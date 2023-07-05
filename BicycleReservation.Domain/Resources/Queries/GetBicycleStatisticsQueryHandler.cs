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
    public class GetBicycleStatisticsQueryHandler : IRequestHandler<GetBicycleStatisticsQuery, BicycleStatisticsResponse>
    {
        private readonly IUnitOfWork uow;
        public GetBicycleStatisticsQueryHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public async Task<BicycleStatisticsResponse> Handle(GetBicycleStatisticsQuery request, CancellationToken cancellationToken)
        {
            var result = await uow.ManagerRepository.GetBicycleStatistics(request.BicycleId);
            return result;
        }
    }
}
