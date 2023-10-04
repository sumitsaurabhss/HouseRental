using HouseRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRental.Application.Repositories
{
    public interface IRentalRepository : IGenericRepository<Rental>
    {
        Task<Rental> GetRentalById(Guid id);
        Task<List<Rental>> GetAllRentals();
        Task<Rental> AddRental(Rental rental);
    }
}
