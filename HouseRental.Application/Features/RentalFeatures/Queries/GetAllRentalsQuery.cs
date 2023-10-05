using HouseRental.Application.DTOs.RentalDtos;
using MediatR;

namespace HouseRental.Application.Features.RentalFeatures.Queries
{
    public class GetAllRentalsQuery : IRequest<List<RentalGetDtoForAdmin>>
    {
    }
}
