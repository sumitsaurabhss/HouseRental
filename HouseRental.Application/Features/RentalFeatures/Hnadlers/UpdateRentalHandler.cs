using AutoMapper;
using HouseRental.Application.Exceptions;
using HouseRental.Application.Features.RentalFeatures.Commands;
using HouseRental.Application.Repositories;
using MediatR;

namespace HouseRental.Application.Features.RentalFeatures.Hnadlers
{
    public class UpdateRentalHandler : IRequestHandler<UpdateRentalCommand>
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly IHouseRepository _houseRepository;
        private readonly IMapper _mapper;

        public UpdateRentalHandler(IRentalRepository rentalRepository, IHouseRepository houseRepository, IMapper mapper)
        {
            _rentalRepository = rentalRepository;
            _houseRepository = houseRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateRentalCommand request, CancellationToken cancellationToken)
        {
            var rental = await _rentalRepository.Get(request.Id);
            if (rental == null)
                throw new NotFoundException("Agreements", request.Id);
            rental.RentalEndDate = rental.RentalStartDate.AddDays(request.Duration - 1);
            var house = await _houseRepository.Get(rental.HouseId);
            rental.TotalRentalCost = house.RentalCostPerMonth * request.Duration;
            await _rentalRepository.Update(rental);
            return Unit.Value;
        }
    }
}
