using HouseRental.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HouseRental.Infrastructure.Contexts
{
    public class HouseRentalDbContext : DbContext
    {
        public HouseRentalDbContext(DbContextOptions<HouseRentalDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HouseRentalDbContext).Assembly);

            modelBuilder.Entity<Rental>()
                .Property(p => p.TotalRentalCost)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<House>()
               .Property(p => p.RentalCostPerMonth)
               .HasColumnType("decimal(18,2)");


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<House> Houses { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
