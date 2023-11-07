using CarWorkshopMVC.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshopMVC.Infrastructure.Persistance
{
    public class CarWorkshopDbContext : IdentityDbContext
    {
        public CarWorkshopDbContext(DbContextOptions<CarWorkshopDbContext> options) : base(options)
        {

        }
        public DbSet<CarWorkshop>  CarWorkshops { get; set; }
        public DbSet<CarWorkshopService> Services { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("data source=(localdb)\\MSSQLLocalDB;initial catalog=CarWorkshopDB; integrated security=true");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CarWorkshop>()
                .OwnsOne(c => c.ContactDetails);
           
            modelBuilder.Entity<CarWorkshop>().HasMany(x => x.Services)
                .WithOne(x => x.CarWorkshop)
                .HasForeignKey(x => x.CarWorkshopId);
        }

    }
}
