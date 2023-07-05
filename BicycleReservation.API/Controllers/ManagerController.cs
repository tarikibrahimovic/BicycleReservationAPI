using BicycleReservation.Domain.Repository;
using BicycleReservation.Domain.Resources.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BicycleReservation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Manager")]
    public class ManagerController : ControllerBase
    {
        private readonly IMediator mediator;

        public ManagerController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("statistics")]
        public async Task<IActionResult> GetOverallStatistics()
        {
            var query = new GetOverallStatisticsQuery();
            var response = await mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("station/{id}")]
        public async Task<IActionResult> GetStationStatistics(int id)
        {
            var query = new GetStationStatisticsQuery()
            {
                Id = id
            };
            var response = await mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("bicycle/{id}")]
        public async Task<IActionResult> GetBicycleStatistics(string id)
        {
            var query = new GetBicycleStatisticsQuery()
            {
                BicycleId = id
            };
            var response = await mediator.Send(query);
            return Ok(response);
        }
    }
}
