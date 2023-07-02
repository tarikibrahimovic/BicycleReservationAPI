using BicycleReservation.Domain.DTO.Auth;
using BicycleReservation.Domain.Entities;
using NovinskaAgencija.data.DTO.Auth.request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleReservation.Domain.Repository
{
    public interface IAuthRepository : IGenericRepository<User, int>
    {
        public Task<LoginResponse> Login(LoginRequest request);
        public Task<LoginResponse> Register(RegisterRequest request);
        public Task<LoginResponse> Verify(VerifyRequest request);
        public Task<SendEmailRequest> ForgotPassword(SendEmailRequest request);
        public Task<SendEmailRequest> ResetPassword(ResetPassword request);
        public Task<SendEmailRequest> ResendVerificationToken(SendEmailRequest request);
        public Task<LoginResponse> CheckToken();
    }
}
