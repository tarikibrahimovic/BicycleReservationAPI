using BicycleReservation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BicycleReservation.DataAccess.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bicycle>().Property(x => x.Type).HasConversion<string>();
            modelBuilder.Entity<Bicycle>().Property(x => x.Id).ValueGeneratedNever();


            CreatePasswordHash("admin123", out byte[] passwordHash, out byte[] passwordSalt);
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = -1,
                    FirstName = "Admin",
                    LastName = "Admin",
                    Email = "admin@admin.com",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Username = "admin",
                    ImageUrl = null,
                    Role = Role.Admin,
                    VerificationToken = null,
                    ForgotPasswordToken = null
                }
                );
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Station> Stations { get; set; }   
        public DbSet<Bicycle> Bicycles { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<UserCredits> Credits { get; set; }
        public DbSet<Breakdown> Breakdowns { get; set; }
    }
}
