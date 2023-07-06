using BicycleReservation.Domain.DTO.Servicer;
using BicycleReservation.Domain.DTO.User;
using BicycleReservation.Domain.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BicycleReservation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public StationController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetStations()
        {
            var stations = await unitOfWork.StationRepository.GetAll();
            return Ok(stations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStation(int id)
        {
            var stations = await unitOfWork.StationRepository.GetStation(id);
            return Ok(stations);
        }
    }
}
