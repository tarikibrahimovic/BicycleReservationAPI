using BicycleReservation.Domain.DTO.Auth;
using BicycleReservation.Domain.DTO.User;
using BicycleReservation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleReservation.Domain.Repository
{
    public interface IUserRepository : IGenericRepository<User, int>
    {
        public Task<LoginResponse> ChangeUsername(ChangeUsernameRequest request);
        public Task<LoginResponse> ChangePassword(ChangePasswordRequest request);
        public Task<LoginResponse> UploadImage(UploadImage image);
        public Task<LoginResponse> DeleteImage();
        public Task<bool> DeleteUser(DeleteAccRequest request);
        public Task<LoginResponse> DepositCredits(DepositCreditsRequest request);
    }
}
