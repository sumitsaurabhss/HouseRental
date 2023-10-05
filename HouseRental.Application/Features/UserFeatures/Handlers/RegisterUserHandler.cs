using AutoMapper;
using HouseRental.Application.DTOs.UserDtos;
using HouseRental.Application.Features.UserFeatures.Commands;
using HouseRental.Application.Repositories;
using HouseRental.Domain.Entities;
using MediatR;

namespace HouseRental.Application.Features.UserFeatures.Handlers
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, UserDetailsDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public RegisterUserHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDetailsDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request.RegisterInfo);
            user.Id = Guid.NewGuid();
            user = await _userRepository.Signup(user);
            return _mapper.Map<UserDetailsDto>(user);
        }
    }
}
