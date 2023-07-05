using BicycleReservation.Domain.DTO.Servicer;
using BicycleReservation.Domain.Entities;
using BicycleReservation.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleReservation.Domain.Resources.Queries
{
    public class GetBicyclesWithServicesQueryHandler : IRequestHandler<GetBicyclesWithServicesQuery, List<BicycleWithService>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetBicyclesWithServicesQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<List<BicycleWithService>> Handle(GetBicyclesWithServicesQuery request, CancellationToken cancellationToken)
        {
            return await unitOfWork.ServicerRepository.GetBicyclesWithServices();
        }
    }
}
