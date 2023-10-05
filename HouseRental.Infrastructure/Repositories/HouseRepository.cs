using HouseRental.Application.Repositories;
using HouseRental.Domain.Entities;
using HouseRental.Infrastructure.Contexts;

namespace HouseRental.Infrastructure.Repositories
{
    public class HouseRepository : GenericRepository<House>, IHouseRepository
    {
        public HouseRepository(HouseRentalDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}
