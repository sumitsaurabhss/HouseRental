using AutoMapper;
using HouseRental.Application.DTOs.RentalDtos;
using HouseRental.Application.Exceptions;
using HouseRental.Application.Features.RentalFeatures.Queries;
using HouseRental.Application.Repositories;
using MediatR;

namespace HouseRental.Application.Features.RentalFeatures.Hnadlers
{
    public class GetRentalByIdHandler : IRequestHandler<GetRentalByIdQuery, RentalGetDtoForUser>
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly IMapper _mapper;

        public GetRentalByIdHandler(IRentalRepository rentalRepository, IMapper mapper)
        {
            _rentalRepository = rentalRepository;
            _mapper = mapper;
        }

        public async Task<RentalGetDtoForUser> Handle(GetRentalByIdQuery request, CancellationToken cancellationToken)
        {
            var rental = await _rentalRepository.GetRentalById(request.Id);
            if (rental == null)
                throw new NotFoundException("Agreements", request.Id);
            return _mapper.Map<RentalGetDtoForUser>(rental);
        }
    }
}