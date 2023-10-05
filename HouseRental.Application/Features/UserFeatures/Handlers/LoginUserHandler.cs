using AutoMapper;
using HouseRental.Application.DTOs.UserDtos;
using HouseRental.Application.Exceptions;
using HouseRental.Application.Features.UserFeatures.Commands;
using HouseRental.Application.Repositories;
using MediatR;

namespace HouseRental.Application.Features.UserFeatures.Handlers
{
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, UserDetailsDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public LoginUserHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDetailsDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.Signin(request.Credentials.Email, request.Credentials.Password);
            if (user == null)
                throw new NotFoundException(request.Credentials.Email, request.Credentials.Password);
            return _mapper.Map<UserDetailsDto>(user);
        }
    }
}
