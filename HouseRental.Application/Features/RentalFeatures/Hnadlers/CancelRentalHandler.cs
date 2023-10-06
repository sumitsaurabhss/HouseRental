using AutoMapper;
using HouseRental.Application.Exceptions;
using HouseRental.Application.Features.RentalFeatures.Commands;
using HouseRental.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRental.Application.Features.RentalFeatures.Hnadlers
{
    public class CancelRentalHandler : IRequestHandler<CancelRentalCommand>
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly IMapper _mapper;

        public CancelRentalHandler(IRentalRepository rentalRepository, IMapper mapper)
        {
            _rentalRepository = rentalRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CancelRentalCommand request, CancellationToken cancellationToken)
        {
            var rental = await _rentalRepository.Get(request.RentalId);
            if (rental == null)
                throw new NotFoundException("Agreements", request.RentalId);
            rental.IsReturned = true;
            await _rentalRepository.Update(rental);
            return Unit.Value;
        }
    }
}