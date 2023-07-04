using BicycleReservation.Domain.DTO.Servicer;
using BicycleReservation.Domain.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BicycleReservation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Servicer,Admin")]
    public class ServicerController : ControllerBase
    {
        public IUnitOfWork unitOfWork { get; set; }
        public ServicerController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
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
    }
}
