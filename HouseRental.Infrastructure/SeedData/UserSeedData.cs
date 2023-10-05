using HouseRental.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseRental.Infrastructure.SeedData
{
    public class UserSeedData : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User
                {
                    Name = "Admin1",
                    Email = "admin1@mail.com",
                    Password = "Admin@123",
                    IsAdmin = true
                },
                new User
                {
                    Name = "Admin2",
                    Email = "admin2@mail.com",
                    Password = "Admin@123",
                    IsAdmin = true
                },
                new User
                {
                    Name = "Aman",
                    Email = "aman@mail.com",
                    Password = "Aman@123",
                    IsAdmin = false
                },
                new User
                {
                    Name = "Rohan",
                    Email = "rohan@mail.com",
                    Password = "Rohan@123",
                    IsAdmin = false
                },
                new User
                {
                    Name = "Sana",
                    Email = "sana@mail.com",
                    Password = "Sana@123",
                    IsAdmin = false
                }
            );
        }
    }
}
