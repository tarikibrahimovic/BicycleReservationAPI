using BicycleReservation.Domain.Entities;
using BicycleReservation.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleReservation.Domain.Resources.Commands.Create
{
    public class ServiceBicycleCommandHandler : IRequestHandler<ServiceBicycleCommand, Service>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ServiceBicycleCommandHandler(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<Service> Handle(ServiceBicycleCommand request, CancellationToken cancellationToken)
        {
            var service = await _unitOfWork.ServicerRepository.ServiceBicycle(request);
            return service;
        }
    }
}
