using HouseRental.Application.DTOs.RentalDtos;
using MediatR;

namespace HouseRental.Application.Features.RentalFeatures.Commands
{
    public class CreateRentalCommand : IRequest<RentalGetDtoForUser>
    {
        public RentalCreateDto RentalInfo { get; set; } = null!;
    }
}
