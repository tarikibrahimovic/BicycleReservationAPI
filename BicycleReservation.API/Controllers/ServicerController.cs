using BicycleReservation.Domain.DTO.Servicer;
using BicycleReservation.Domain.Repository;
using BicycleReservation.Domain.Resources.Commands.Create;
using BicycleReservation.Domain.Resources.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BicycleReservation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Servicer")]
    public class ServicerController : ControllerBase
    {
        public IUnitOfWork unitOfWork { get; set; }
        private readonly IHttpContextAccessor acc;
        private readonly IMediator mediator;
        public ServicerController(IUnitOfWork unitOfWork, IMediator mediator, IHttpContextAccessor acc)
        {
            this.unitOfWork = unitOfWork;
            this.acc = acc;
            this.mediator = mediator;
        }

        [HttpPost("resolve")]
        public async Task<IActionResult> Resolve([FromBody] ResolveRequest request)
        {
            var result = await unitOfWork.ServicerRepository.ResolveBreakdown(request);
            return Ok(result);
        }

        [HttpGet("breakdowns")]
        public async Task<IActionResult> GetBreakdowns()
        {
            var result = await unitOfWork.ServicerRepository.GetBreakdowns();
            return Ok(result);
        }

        [HttpPost("Move")]
        public async Task<IActionResult> Move(MoveRequest request)
        {
            var stations = await unitOfWork.ServicerRepository.Move(request);
            return Ok(stations);
        }

        [HttpPost("service")]
        public async Task<IActionResult> Service(ServiceBicycleRequest request)
        {
            var command = new ServiceBicycleCommand()
            {
                BicycleId = request.BicycleId,
                UserId = int.Parse(acc.HttpContext.User.FindFirst(ClaimTypes.PrimarySid).Value)
            };
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("services")]
        public async Task<IActionResult> GetServices()
        {
            var query = new GetBicyclesWithServicesQuery();
            var result = await mediator.Send(query);
            return Ok(result);
        }

    }
}
