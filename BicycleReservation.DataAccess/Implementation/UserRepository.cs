using BicycleReservation.DataAccess.Context;
using BicycleReservation.Domain.DTO.Auth;
using BicycleReservation.Domain.DTO.User;
using BicycleReservation.Domain.Entities;
using BicycleReservation.Domain.Repository;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.Security.Cryptography;

namespace BicycleReservation.DataAccess.Implementation
{
    public class UserRepository : GenericRepository<User, int>, IUserRepository 
    {
        private readonly IConfiguration _configuration;
        private Cloudinary cloudinary;
        private Account account;
        private readonly IUnitOfWork _unitOfWork;
        public IHttpContextAccessor _acc { get; set; }
        public UserRepository(DataContext context, IConfiguration configuration, IHttpContextAccessor _acc, IUnitOfWork unitOfWork) : base(context)
        {
            _configuration = configuration;
            account = new Account(configuration.GetSection("Cloudinary:Cloud").Value,
                configuration.GetSection("Cloudinary:ApiKey").Value,
                configuration.GetSection("Cloudinary:ApiSecret").Value);
            cloudinary = new Cloudinary(account);
            this._acc = _acc;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> ChangeUsername(ChangeUsernameRequest request)
        {
            try
            {
                int userId = int.Parse(_acc.HttpContext.User.FindFirst(ClaimTypes.PrimarySid).Value);
                User user = GetById(userId);
                if(user == null)
                {
                    throw new Exception("User not found");
                }
                if(user.Username == request.Username)
                {
                    throw new Exception("Username is the same");
                }
                if(request.Username.Length == 0)
                {
                    throw new Exception("Username is null");
                }
                user.Username = request.Username;
                Update(user);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error");
            }
        }

        public async Task<bool> ChangePassword(ChangePasswordRequest request)
        {
            try
            {
                int userId = int.Parse(_acc.HttpContext.User.FindFirst(ClaimTypes.PrimarySid).Value);
                User user = GetById(userId);
                if (user == null)
                {
                    throw new Exception("User not found");
                }
                if(request.NewPassword.Length == 0)
                {
                    throw new Exception("New password is null");
                }
                if(!VerifyPasswordHash(request.OldPassword, user.PasswordHash, user.PasswordSalt))
                {
                    throw new Exception("Old password is not correct");
                }

                CreatePasswordHash(request.NewPassword, out byte[] passwordHash, out byte[] passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                Update(user);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("User not found");
            }
        }

        public async Task<LinkResponse> UploadImage(UploadImage image)
        {
            try
            {
                if (image.ProfileImage == null)
                {
                    throw new Exception("There is no Image");
                }
                int userId = int.Parse(_acc.HttpContext.User.FindFirst(ClaimTypes.PrimarySid).Value);
                User user = GetById(userId);
                if (user == null)
                {
                    throw new Exception("User not found");
                }
                var filePath = Path.GetTempFileName();

                using (var stream = System.IO.File.Create(filePath))
                {
                    image.ProfileImage.CopyTo(stream);
                }
                var guid = Guid.NewGuid().ToString();
                var profilePicturePublicId = $"{_configuration.GetSection("Cloudinary:ProfilePicsFolderName").Value}/user{guid}_profile-picture";
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(filePath),
                    PublicId = profilePicturePublicId,
                };
                var uploadResult = cloudinary.Upload(uploadParams);
                user.ImageUrl = uploadResult.Url.ToString();
                _unitOfWork.Save();
                return new LinkResponse { ImageUrl = uploadResult.Uri.ToString() };
            }
            catch (Exception ex)
            {
                throw new Exception("Error");
            }
        }
        public async Task<bool> DeleteImage()
        {
            try
            {
                int userId = int.Parse(_acc.HttpContext.User.FindFirst(ClaimTypes.PrimarySid).Value);
                User user = GetById(userId);
                if (user == null)
                {
                    throw new Exception("User not found");
                }
                if (user.ImageUrl != null)
                {
                    user.ImageUrl = null;
                    var profilePicturePublicId = $"{_configuration.GetSection("Cloudinary:ProfilePicsFolderName").Value}/user{userId}_profile-picture";
                    var deletionParams = new DeletionParams(profilePicturePublicId)
                    {
                        ResourceType = ResourceType.Image
                    };

                    cloudinary.Destroy(deletionParams);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    throw new Exception("Error");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error");
            }
        }
        public async Task<bool> DeleteUser(DeleteAccRequest request)
        {
            try
            {
                int userId = int.Parse(_acc.HttpContext.User.FindFirst(ClaimTypes.PrimarySid).Value);
                User user = GetById(userId);
                if (user == null)
                {
                    throw new Exception("User not found");
                }
                if(!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
                {
                    throw new Exception("Old password is not correct");
                }
                if (user.ImageUrl != null)
                {
                    var profilePicturePublicId = $"{_configuration.GetSection("Cloudinary:ProfilePicsFolderName").Value}/user{userId}_profile-picture";
                    var deletionParams = new DeletionParams(profilePicturePublicId)
                    {
                        ResourceType = ResourceType.Image
                    };
                    cloudinary.Destroy(deletionParams);
                    Delete(user);
                    _unitOfWork.Save();
                    return true;
                }
                else
                {
                    Delete(user);
                    _unitOfWork.Save();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error");
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
