using BicycleReservation.Domain.DTO.Auth;
using BicycleReservation.Domain.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NovinskaAgencija.data.DTO.Auth.request;

namespace BicycleReservation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public IUnitOfWork unitOfWork { get; set; }
        public AuthController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var userFromDb = await unitOfWork.AuthRepository.Login(request);
            if (userFromDb == null)
            {
                return Unauthorized();
            }
            return Ok(userFromDb);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var userFromDb = await unitOfWork.AuthRepository.Register(request);
            if (userFromDb == null)
            {
                return BadRequest();
            }
            return Ok(userFromDb);
        }

        [HttpPost("verify")]
        public async Task<IActionResult> Verify([FromBody] VerifyRequest request)
        {
            var userFromDb = await unitOfWork.AuthRepository.Verify(request);
            if (userFromDb == null)
            {
                return BadRequest();
            }
            return Ok(userFromDb);
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] SendEmailRequest request)
        {
            var userFromDb = await unitOfWork.AuthRepository.ForgotPassword(request);
            if (userFromDb == null)
            {
                return BadRequest();
            }
            return Ok(userFromDb);
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPassword request)
        {
            var userFromDb = await unitOfWork.AuthRepository.ResetPassword(request);
            if (userFromDb == null)
            {
                return BadRequest();
            }
            return Ok(userFromDb);
        }

        [HttpPost("resend-verification-token")]
        public async Task<IActionResult> ResendVerificationToken([FromBody] SendEmailRequest request)
        {
            var userFromDb = await unitOfWork.AuthRepository.ResendVerificationToken(request);
            if (userFromDb == null)
            {
                return BadRequest();
            }
            return Ok(userFromDb);
        }

        [HttpGet("check-token")]
        [Authorize]
        public async Task<IActionResult> CheckToken()
        {
            var userFromDb = await unitOfWork.AuthRepository.CheckToken();
            if (userFromDb == null)
            {
                return BadRequest();
            }
            return Ok(userFromDb);
        }
    }
}
