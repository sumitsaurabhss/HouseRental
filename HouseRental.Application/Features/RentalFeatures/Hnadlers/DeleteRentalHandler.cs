using AutoMapper;
using HouseRental.Application.Exceptions;
using HouseRental.Application.Features.RentalFeatures.Commands;
using HouseRental.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace HouseRental.Application.Features.RentalFeatures.Hnadlers
{
    public class DeleteRentalHandler : IRequestHandler<DeleteRentalCommand>
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly IHouseRepository _houseRepository;
        private readonly IMapper _mapper;

        public DeleteRentalHandler(IRentalRepository rentalRepository, IHouseRepository houseRepository, IMapper mapper)
        {
            _rentalRepository = rentalRepository;
            _houseRepository = houseRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteRentalCommand request, CancellationToken cancellationToken)
        {
            var rental = await _rentalRepository.Get(request.Id);
            if (rental == null)
            {
                throw new NotFoundException("Agreement", request.Id);
            }
            var house = await _houseRepository.Get(rental.HouseId);
            house.IsAvailable = true;
            await _houseRepository.Update(house);
            await _rentalRepository.Delete(rental);
            return Unit.Value;
        }
    }
}
