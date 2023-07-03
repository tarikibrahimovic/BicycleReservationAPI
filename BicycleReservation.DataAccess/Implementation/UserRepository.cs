using BicycleReservation.DataAccess.Context;
using BicycleReservation.Domain.DTO.Auth;
using BicycleReservation.Domain.DTO.User;
using BicycleReservation.Domain.Entities;
using BicycleReservation.Domain.Repository;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

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

        public async Task<LoginResponse> ChangeUsername(ChangeUsernameRequest request)
        {
            try
            {
                int userId = int.Parse(_acc.HttpContext.User.FindFirst(ClaimTypes.PrimarySid).Value);
                User user = await context.Users.Include(u => u.Credits).FirstOrDefaultAsync(x => x.Id == userId);
                if (user == null || user.VerificationToken != null)
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
                //_unitOfWork.Save();
                await context.SaveChangesAsync();
                return new LoginResponse
                {
                    User = new Domain.DTO.User.UserDTO()
                    {
                        Id = user.Id,
                        Email = user.Email,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Username = user.Username,
                        Role = user.Role,
                        Credits = user.Credits.Credits,
                        Verified = user.VerificationToken != null ? false : true,
                        ImageUrl = user.ImageUrl,
                    },
                    Token = CreateToken(user),
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<LoginResponse> ChangePassword(ChangePasswordRequest request)
        {
            try
            {
                int userId = int.Parse(_acc.HttpContext.User.FindFirst(ClaimTypes.PrimarySid).Value);
                User user = await context.Users.Include(u => u.Credits).FirstOrDefaultAsync(x => x.Id == userId);
                if (user == null || user.VerificationToken != null)
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
                //_unitOfWork.Save();
                await context.SaveChangesAsync();
                return new LoginResponse
                {
                    User = new Domain.DTO.User.UserDTO()
                    {
                        Id = user.Id,
                        Email = user.Email,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Username = user.Username,
                        Role = user.Role,
                        Credits = user.Credits.Credits,
                        Verified = user.VerificationToken != null ? false : true,
                        ImageUrl = user.ImageUrl,
                    },
                    Token = CreateToken(user),
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<LoginResponse> UploadImage(UploadImage image)
        {
            try
            {
                if (image.ProfileImage == null)
                {
                    throw new Exception("There is no Image");
                }
                int userId = int.Parse(_acc.HttpContext.User.FindFirst(ClaimTypes.PrimarySid).Value);
                User user = await context.Users.Include(u => u.Credits).FirstOrDefaultAsync(x => x.Id == userId);
                if (user == null || user.VerificationToken != null)
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
                //_unitOfWork.Save();
                await context.SaveChangesAsync();
                //return new LinkResponse { ImageUrl = uploadResult.Uri.ToString() };
                return new LoginResponse
                {
                    User = new Domain.DTO.User.UserDTO()
                    {
                        Id = user.Id,
                        Email = user.Email,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Username = user.Username,
                        Role = user.Role,
                        Credits = user.Credits.Credits,
                        Verified = user.VerificationToken != null ? false : true,
                        ImageUrl = user.ImageUrl,
                    },
                    Token = CreateToken(user),
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<LoginResponse> DeleteImage()
        {
            try
            {
                int userId = int.Parse(_acc.HttpContext.User.FindFirst(ClaimTypes.PrimarySid).Value);
                User user = await context.Users.Include(u => u.Credits).FirstOrDefaultAsync(x => x.Id == userId);
                if (user == null || user.VerificationToken != null)
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
                    await context.SaveChangesAsync();
                    return new LoginResponse
                    {
                        User = new Domain.DTO.User.UserDTO()
                        {
                            Id = user.Id,
                            Email = user.Email,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            Username = user.Username,
                            Role = user.Role,
                            Credits = user.Credits.Credits,
                            Verified = user.VerificationToken != null ? false : true,
                            ImageUrl = user.ImageUrl,
                        },
                        Token = CreateToken(user),
                    };
                }
                else
                {
                    throw new Exception("Error");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteUser(DeleteAccRequest request)
        {
            try
            {
                int userId = int.Parse(_acc.HttpContext.User.FindFirst(ClaimTypes.PrimarySid).Value);
                User user = GetById(userId);
                if (user == null || user.VerificationToken != null)
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
                throw new Exception(ex.Message);
            }
        }

        public async Task<LoginResponse> DepositCredits(DepositCreditsRequest request)
        {
            try
            {
                int userId = int.Parse(_acc.HttpContext.User.FindFirst(ClaimTypes.PrimarySid).Value);
                User user = await context.Users.Include(u => u.Credits).FirstOrDefaultAsync(x => x.Id == userId);
                if (user == null || user.Role != Domain.Entities.Role.Client || user.VerificationToken != null)
                {
                    throw new Exception("User not found");
                }
                user.Credits.Credits += request.Credits;
                await context.SaveChangesAsync();
                return new LoginResponse
                {
                    User = new Domain.DTO.User.UserDTO()
                    {
                        Id = user.Id,
                        Email = user.Email,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Username = user.Username,
                        Role = user.Role,
                        Credits = user.Credits.Credits,
                        Verified = user.VerificationToken != null ? false : true,
                        ImageUrl = user.ImageUrl,
                    },
                    Token = CreateToken(user),
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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

        public string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.PrimarySid, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Token").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
