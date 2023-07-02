using BicycleReservation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleReservation.DataAccess.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bicycle>().Property(x => x.Type).HasConversion<string>();
            modelBuilder.Entity<Bicycle>().Property(x => x.Id).ValueGeneratedNever();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Station> Stations { get; set; }   
        public DbSet<Bicycle> Bicycles { get; set; }
    }
}
