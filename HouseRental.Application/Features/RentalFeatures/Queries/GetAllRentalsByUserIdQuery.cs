using HouseRental.Application.DTOs.RentalDtos;
using MediatR;

namespace HouseRental.Application.Features.RentalFeatures.Queries
{
    public class GetAllRentalsByUserIdQuery : IRequest<List<RentalGetDtoForUser>>
    {
        public Guid UserId { get; set; }
    }
}
