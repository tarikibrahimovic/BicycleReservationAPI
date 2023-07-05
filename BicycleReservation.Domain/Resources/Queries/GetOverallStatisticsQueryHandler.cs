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
    public class GetOverallStatisticsQueryHandler : IRequestHandler<GetOverallStatisticsQuery, OverallStatisticsResponse>
    {
        private readonly IUnitOfWork uow;

        public GetOverallStatisticsQueryHandler(IUnitOfWork uow)
        {
            this.uow = uow;        
        }

        public async Task<OverallStatisticsResponse> Handle(GetOverallStatisticsQuery request, CancellationToken cancellationToken)
        {

            var result = await uow.ManagerRepository.GetOverallStatistics();
            return result;
        }
    }
}
