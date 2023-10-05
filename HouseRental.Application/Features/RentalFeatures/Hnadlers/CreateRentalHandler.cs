using AutoMapper;
using HouseRental.Application.DTOs.RentalDtos;
using HouseRental.Application.Features.RentalFeatures.Commands;
using HouseRental.Application.Repositories;
using HouseRental.Domain.Entities;
using MediatR;

namespace HouseRental.Application.Features.RentalFeatures.Hnadlers
{
    public class CreateRentalHandler : IRequestHandler<CreateRentalCommand, RentalGetDtoForUser>
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly IMapper _mapper;

        public CreateRentalHandler(IRentalRepository rentalRepository, IMapper mapper)
        {
            _rentalRepository = rentalRepository;
            _mapper = mapper;
        }

        public async Task<RentalGetDtoForUser> Handle(CreateRentalCommand request, CancellationToken cancellationToken)
        {
            var rental = _mapper.Map<Rental>(request.RentalInfo);
            rental = await _rentalRepository.AddRental(rental);
            return _mapper.Map<RentalGetDtoForUser>(rental);
        }
    }
}
