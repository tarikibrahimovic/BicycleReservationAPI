using BicycleReservation.Domain.DTO.User;
using BicycleReservation.Domain.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BicycleReservation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        public IUnitOfWork unitOfWork { get; set; }
        public UserController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpPost("change-username")]
        public async Task<IActionResult> ChangeUsername([FromBody] ChangeUsernameRequest request)
        {
            var userFromDb = await unitOfWork.UserRepository.ChangeUsername(request);
            if (userFromDb == null)
            {
                return BadRequest();
            }
            return Ok(userFromDb);
        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
        {
            var userFromDb = await unitOfWork.UserRepository.ChangePassword(request);
            if (userFromDb == null)
            {
                return BadRequest();
            }
            return Ok(userFromDb);
        }

        [HttpPost("upload-image")]
        public async Task<IActionResult> ChangeProfilePicture([FromForm] UploadImage request)
        {
            var userFromDb = await unitOfWork.UserRepository.UploadImage(request);
            if (userFromDb == null)
            {
                return BadRequest();
            }
            return Ok(userFromDb);
        }

        [HttpDelete("delete-image")]
        public async Task<IActionResult> DeleteProfilePicture()
        {
            var userFromDb = await unitOfWork.UserRepository.DeleteImage();
            if (userFromDb == null)
            {
                return BadRequest();
            }
            return Ok(userFromDb);
        }

        [HttpPost("delete-account")]
        public async Task<IActionResult> DeleteAccount([FromBody] DeleteAccRequest request)
        {
            var userFromDb = await unitOfWork.UserRepository.DeleteUser(request);
            if (userFromDb == false)
            {
                return BadRequest();
            }
            return Ok(userFromDb);
        }

        [HttpPost("deposit-credits")]
        public async Task<IActionResult> DepositCredits([FromBody] DepositCreditsRequest request)
        {
            var userFromDb = await unitOfWork.UserRepository.DepositCredits(request);
            if (userFromDb == null)
            {
                return BadRequest();
            }
            return Ok(userFromDb);
        }
    }
}
