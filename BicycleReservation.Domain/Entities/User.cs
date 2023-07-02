using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleReservation.Domain.Entities
{
    public enum Role
    {
        Servicer,
        Menagement,
        Client,
        Admin
    }
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public byte[]? PasswordHash { get; set; } = new byte[32];
        public byte[]? PasswordSalt { get; set; } = new byte[32];
        public string? ImageUrl { get; set; } = string.Empty;
        public string? VerificationToken { get; set; } = string.Empty;
        public string? ForgotPasswordToken { get; set; } = string.Empty;
        public Role Role { get; set; }
    }
}
