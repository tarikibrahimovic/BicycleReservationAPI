using BicycleReservation.Domain.DTO.Admin;
using BicycleReservation.Domain.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BicycleReservation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public AdminController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpPost("stations")]
        public async Task<IActionResult> AddStation([FromBody] AddStationRequest request)
        {
            var station = await unitOfWork.AdminRepository.AddStation(request);
            return Ok(station);
        }

        [HttpPost("stations/{id}")]
        public async Task<IActionResult> AddBicycle(int id, [FromBody] AddBicycleRequest request)
        {
            var bicycle = await unitOfWork.AdminRepository.AddBicycle(id, request);
            return Ok(bicycle);
        }

        [HttpDelete("user/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await unitOfWork.AdminRepository.DeleteUser(id);
            return Ok(result);
        }

        [HttpPost("promote")]
        public async Task<IActionResult> PromoteUser([FromBody] PromoteRequest request)
        {
            var result = await unitOfWork.AdminRepository.PromoteUser(request);
            return Ok(result);
        }

    }
}
