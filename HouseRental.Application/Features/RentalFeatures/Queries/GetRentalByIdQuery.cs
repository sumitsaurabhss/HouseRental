using HouseRental.Application.DTOs.RentalDtos;
using MediatR;

namespace HouseRental.Application.Features.RentalFeatures.Queries
{
    public class GetRentalByIdQuery : IRequest<RentalGetDtoForUser>
    {
        public Guid Id { get; set; }
    }
}
