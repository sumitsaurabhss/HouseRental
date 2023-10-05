using HouseRental.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseRental.Infrastructure.SeedData
{
    public class HouseSeedData : IEntityTypeConfiguration<House>
    {
        public void Configure(EntityTypeBuilder<House> builder)
        {
            builder.HasData(
                new House
                {
                    Type = "2BHK",
                    Address = "Andrews Ganj, South Delhi",
                    RentalCostPerMonth = 20000,
                    IsAvailable = true
                },
                new House
                {
                    Type = "3BHK",
                    Address = "Habibganj, Bhopal",
                    RentalCostPerMonth = 22000,
                    IsAvailable = true
                },
                new House
                {
                    Type = "2BHK",
                    Address = "Budhha Colony, Patna",
                    RentalCostPerMonth = 15000,
                    IsAvailable = true
                },
                new House
                {
                    Type = "1BHK",
                    Address = "Cyber city, Gurugram",
                    RentalCostPerMonth = 10000,
                    IsAvailable = true
                }
            );
        }
    }
}
