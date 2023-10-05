using AutoMapper;
using HouseRental.Application.DTOs.RentalDtos;
using HouseRental.Application.Features.RentalFeatures.Queries;
using HouseRental.Application.Repositories;
using MediatR;

namespace HouseRental.Application.Features.RentalFeatures.Hnadlers
{
    public class GetAllRentalsByUserIdHandler : IRequestHandler<GetAllRentalsByUserIdQuery, List<RentalGetDtoForUser>>
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly IMapper _mapper;

        public GetAllRentalsByUserIdHandler(IRentalRepository rentalRepository, IMapper mapper)
        {
            _rentalRepository = rentalRepository;
            _mapper = mapper;
        }

        public async Task<List<RentalGetDtoForUser>> Handle(GetAllRentalsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var rentals = await _rentalRepository.GetAllRentals();
            rentals = rentals.Where(rental => rental.UserId == request.UserId).ToList();
            return _mapper.Map<List<RentalGetDtoForUser>>(rentals);
        }
    }
}