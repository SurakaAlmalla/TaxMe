using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TaxMeData.Models;

namespace TaxMeData.Context
{
    public class TaxMeDbContext : DbContext
    {
        public TaxMeDbContext(DbContextOptions<TaxMeDbContext> options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //    optionsBuilder.UseSqlServer("Server=. ;Database=TexMe ;Trusted_Connections=true ; ");

        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Driver> Drivers { get; set; }

        public DbSet<Ride> Rides { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<RideRequest> RideRequests { get; set; }

    }
}
