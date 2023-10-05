using HouseRental.Application.Repositories;
using HouseRental.Domain.Entities;
using HouseRental.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HouseRental.Infrastructure.Repositories
{
    public class RentalRepository : GenericRepository<Rental>, IRentalRepository
    {
        private readonly HouseRentalDbContext _dbContext;

        public RentalRepository(HouseRentalDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Rental> AddRental(Rental rental)
        {
            await _dbContext.Rentals.AddAsync(rental);
            var house = await _dbContext.Houses.FirstOrDefaultAsync(house => house.Id == rental.HouseId);
            house.IsAvailable = false;
            await _dbContext.SaveChangesAsync();
            return rental;
        }

        public async Task<List<Rental>> GetAllRentals()
        {
            var rentals = await _dbContext.Rentals
                .Include(house => house.House)
                .Include(user => user.User)
                .ToListAsync();
            return rentals;
        }

        public async Task<Rental> GetRentalById(Guid id)
        {
            var rental = await _dbContext.Rentals
                .Include(house => house.House)
                .Include(user => user.User)
                .FirstOrDefaultAsync(q => q.Id == id);
            return rental;
        }
    }
}
