using AutoMapper;
using HouseRental.Application.Exceptions;
using HouseRental.Application.Features.HouseFeatures.Commands;
using HouseRental.Application.Repositories;
using MediatR;

namespace HouseRental.Application.Features.HouseFeatures.Handlers
{
    public class DeleteHouseHandler : IRequestHandler<DeleteHouseCommand>
    {
        private readonly IHouseRepository _houseRepository;
        private readonly IMapper _mapper;

        public DeleteHouseHandler(IHouseRepository houseRepository, IMapper mapper)
        {
            _houseRepository = houseRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteHouseCommand request, CancellationToken cancellationToken)
        {
            var house = await _houseRepository.Get(request.Id);
            if(house == null)
                throw new NotFoundException("House", request.Id);
            await _houseRepository.Delete(house);
            throw new NotImplementedException();
        }
    }
}
