using AutoMapper;
using HouseRental.Application.DTOs.HouseDtos;
using HouseRental.Application.Exceptions;
using HouseRental.Application.Features.HouseFeatures.Queries;
using HouseRental.Application.Repositories;
using MediatR;

namespace HouseRental.Application.FeaturesFeatures.House.Handlers
{
    public class GetHouseByIdHandler : IRequestHandler<GetHouseByIdQuery, HouseGetDto>
    {
        private readonly IHouseRepository _houseRepository;
        private readonly IMapper _mapper;

        public GetHouseByIdHandler(IHouseRepository houseRepository, IMapper mapper)
        {
            _houseRepository = houseRepository;
            _mapper = mapper;
        }

        public async Task<HouseGetDto> Handle(GetHouseByIdQuery request, CancellationToken cancellationToken)
        {
            var house = await _houseRepository.Get(request.Id);
            if (house == null)
                throw new NotFoundException("House", request.Id);
            return _mapper.Map<HouseGetDto>(house);
        }
    }
}
