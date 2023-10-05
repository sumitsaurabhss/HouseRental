using HouseRental.Application.DTOs.UserDtos;
using MediatR;

namespace HouseRental.Application.Features.UserFeatures.Commands
{
    public class LoginUserCommand : IRequest<UserDetailsDto>
    {
        public UserLoginDto Credentials { get; set; } = null!;
    }
}
