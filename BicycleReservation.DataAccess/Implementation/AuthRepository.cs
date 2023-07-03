using BicycleReservation.DataAccess.Context;
using BicycleReservation.Domain.Entities;
using BicycleReservation.Domain.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using MimeKit.Text;
using MailKit.Net.Smtp;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using NovinskaAgencija.data.DTO.Auth.request;
using BicycleReservation.Domain.DTO.Auth;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto;
using Microsoft.AspNetCore.Http;

namespace BicycleReservation.DataAccess.Implementation
{
    public class AuthRepository : GenericRepository<User, int>, IAuthRepository
    {
        private readonly IConfiguration _configuration;
        public IHttpContextAccessor acc { get; set; }
        public AuthRepository(DataContext context, IConfiguration configuration, IHttpContextAccessor acc) : base(context)
        {
            _configuration = configuration;
            this.acc = acc;
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

        public int GetUserId(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);
            var tokenS = handler.ReadToken(token) as JwtSecurityToken;
            int userId = int.Parse(tokenS.Claims.First(claim => claim.Type == "unique_name").Value);
            return userId;
        }
        public void SendEmail(string email, string body)
        {
            var sender = _configuration.GetSection("Mail").GetSection("email").Value;
            var password = _configuration.GetSection("Mail").GetSection("password").Value;
            Console.WriteLine(sender + password);
            var emailSender = new MimeMessage();
            emailSender.From.Add(new MailboxAddress("Bicycle Reservation", sender));
            emailSender.To.Add(MailboxAddress.Parse(email));
            emailSender.Subject = "Bicycle Reservation";
            emailSender.Body = new TextPart(TextFormat.Html)
            {
                Text = body
            };
            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, false);
            smtp.Authenticate(sender, password);
            smtp.Send(emailSender);
            smtp.Disconnect(true);
        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {
            try
            {
                User user = await context.Users.Include(u => u.Credits).FirstOrDefaultAsync(x => x.Email == request.Email);
                if (user == null || !VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
                {
                    throw new Exception("Check your credentials and try again");
                }
                bool verified = user.VerificationToken != null ? false : true;
                var jwt = string.Empty;
                double credits = 0;
                jwt = CreateToken(user);
                if (user.Role == Role.Client)
                {
                    credits = user.Credits.Credits;
                }
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
                        Credits = credits,
                        Verified = verified,
                        ImageUrl = user.ImageUrl,
                    },
                    Token = jwt,
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<LoginResponse> Register(RegisterRequest request)
        {
            try
            {
                if (context.Users.Any(x => x.Email == request.Email))
                {
                    throw new Exception("Email already exists");
                }
                if (context.Users.Any(x => x.Username == request.Username))
                {
                    throw new Exception("Username already exists");
                }
                if(request.Password.Length < 8)
                {
                    throw new Exception("Password must be at least 8 characters long");
                }
                CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
                Random random = new Random();
                int code = random.Next(100000, 999999);

                User user = new User
                {
                    Email = request.Email,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Username = request.Username,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Role = Role.Client,
                    VerificationToken = code.ToString(),
                };

                UserCredits credits = new UserCredits
                {
                    Credits = 100,
                    User = user,
                };

                user.Credits = credits;

                // SendEmail(request.Email, "Your verification token is:" + code.ToString());
                await context.Users.AddAsync(user);
                await context.Credits.AddAsync(credits);
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
                    Token = string.Empty,
                };
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<LoginResponse> Verify(VerifyRequest request)
        {
            try
            {
                User user = await context.Users.Include(u => u.Credits).FirstOrDefaultAsync(x => x.Email == request.Email);
                if (user == null)
                {
                    throw new Exception("Email does not exist");
                }
                if(user.VerificationToken == null)
                {
                    throw new Exception("Email is already verified");
                }
                if (user.VerificationToken != request.Token)
                {
                    throw new Exception("Wrong verification token");
                }
                user.VerificationToken = null;
                await context.SaveChangesAsync();
                var jwt = CreateToken(user);
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
                    Token = jwt,
                };
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<SendEmailRequest> ForgotPassword(SendEmailRequest request)
        {
            try
            {
                User user = await context.Users.FirstOrDefaultAsync(x => x.Email == request.Email);
                if (user == null)
                {
                    throw new Exception("Email does not exist");
                }
                Random random = new Random();
                int code = random.Next(100000, 999999);
                user.VerificationToken = code.ToString();
                await context.SaveChangesAsync();
                SendEmail(request.Email, "Your Forgot Password token is:" + code.ToString());
                return new SendEmailRequest
                {
                    Email = user.Email,
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<SendEmailRequest> ResetPassword(ResetPassword request)
        {
            try
            {
                User user = await context.Users.FirstOrDefaultAsync(x => x.Email == request.Email);
                if (user == null)
                {
                    throw new Exception("Email does not exist");
                }
                if (user.VerificationToken != request.Token)
                {
                    throw new Exception("Wrong verification token");
                }
                CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.VerificationToken = null;
                await context.SaveChangesAsync();
                return new SendEmailRequest
                {
                    Email = user.Email,
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<SendEmailRequest> ResendVerificationToken(SendEmailRequest request)
        {
            try
            {
                User user = await context.Users.FirstOrDefaultAsync(x => x.Email == request.Email);
                if (user == null)
                {
                    throw new Exception("Email does not exist");
                }
                if(user.VerificationToken == null)
                {
                    throw new Exception("User already verfied");
                }

                SendEmail(request.Email, "Your Verify token is:" + user.VerificationToken.ToString());
                return new SendEmailRequest
                {
                    Email = user.Email,
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<LoginResponse> CheckToken()
        {
            try
            {
                int userId = int.Parse(acc.HttpContext.User.FindFirst(ClaimTypes.PrimarySid).Value);
                User user = await context.Users.Include(u => u.Credits).FirstOrDefaultAsync(x => x.Id == userId);
                if (user == null)
                {
                    throw new Exception("User not found");
                }
                var jwt = CreateToken(user);
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
                    Token = jwt,
                };
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
