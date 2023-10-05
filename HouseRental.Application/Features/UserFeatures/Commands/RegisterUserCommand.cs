using HouseRental.Application.DTOs.UserDtos;
using MediatR;

namespace HouseRental.Application.Features.UserFeatures.Commands
{
    public class RegisterUserCommand : IRequest<UserDetailsDto>
    {
        public UserRegisterDto RegisterInfo { get; set; } = null!;
    }
}
