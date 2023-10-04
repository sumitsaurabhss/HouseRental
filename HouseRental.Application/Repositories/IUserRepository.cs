using HouseRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRental.Application.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> Signup(User user);
        Task<User> Signin(string email, string password);
    }
}

