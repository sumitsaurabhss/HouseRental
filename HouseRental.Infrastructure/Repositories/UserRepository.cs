using HouseRental.Application.Repositories;
using HouseRental.Domain.Entities;
using HouseRental.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HouseRental.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly HouseRentalDbContext _dbContext;

        public UserRepository(HouseRentalDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> Signin(string email, string password)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
            return user;
        }

        public async Task<User> Signup(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }
    }
}