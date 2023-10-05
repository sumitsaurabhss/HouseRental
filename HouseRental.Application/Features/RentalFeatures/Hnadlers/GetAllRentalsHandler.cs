using AutoMapper;
using HouseRental.Application.DTOs.RentalDtos;
using HouseRental.Application.Features.RentalFeatures.Queries;
using HouseRental.Application.Repositories;
using MediatR;

namespace HouseRental.Application.Features.RentalFeatures.Hnadlers
{
    public class GetAllRentalsHandler : IRequestHandler<GetAllRentalsQuery, List<RentalGetDtoForAdmin>>
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly IMapper _mapper;

        public GetAllRentalsHandler(IRentalRepository rentalRepository, IMapper mapper)
        {
            _rentalRepository = rentalRepository;
            _mapper = mapper;
        }

        public async Task<List<RentalGetDtoForAdmin>> Handle(GetAllRentalsQuery request, CancellationToken cancellationToken)
        {
            var rentals = await _rentalRepository.GetAllRentals();
            return _mapper.Map<List<RentalGetDtoForAdmin>>(rentals);
        }
    }
}
