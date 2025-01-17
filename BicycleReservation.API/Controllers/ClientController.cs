﻿using BicycleReservation.Domain.DTO.Client;
using BicycleReservation.Domain.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BicycleReservation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Client")]
    public class ClientController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public ClientController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpPost("rent")]
        public async Task<IActionResult> RentBicycle([FromBody] BicycleRentRequest request)
        {
            var response = await unitOfWork.ClientRepository.RentBicycle(request);
            return Ok(response);
        }

        [HttpPost("return")]
        public async Task<IActionResult> ReturnBicycle([FromBody] ReturnBicycleRequest request)
        {
            var response = await unitOfWork.ClientRepository.ReturnBicycle(request);
            return Ok(response);
        }

        [HttpGet("rented")]
        public async Task<IActionResult> GetRentedBicycle()
        {
            var response = await unitOfWork.ClientRepository.GetRents();
            return Ok(response);
        }

        [HttpPost("report-breakdown")]
        public async Task<IActionResult> PrijavaGreske(BicycleBreakdownRequest request)
        {
            var stations = await unitOfWork.ClientRepository.BreakdownReport(request);
            return Ok(stations);
        }
    }
}
