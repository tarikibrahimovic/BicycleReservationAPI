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
        public Task<bool> ChangeUsername(ChangeUsernameRequest request);
        public Task<bool> ChangePassword(ChangePasswordRequest request);
        public Task<LinkResponse> UploadImage(UploadImage image);
        public Task<bool> DeleteImage();
        public Task<bool> DeleteUser(DeleteAccRequest request);
    }
}
