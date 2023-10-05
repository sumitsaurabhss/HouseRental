using HouseRental.Application.Repositories;
using HouseRental.Infrastructure.Contexts;
using HouseRental.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HouseRental.Infrastructure
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HouseRentalDbContext>(options =>
               options.UseSqlServer(
                   configuration.GetConnectionString("DefaultConnection")));


            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IHouseRepository, HouseRepository>();
            services.AddScoped<IRentalRepository, RentalRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}