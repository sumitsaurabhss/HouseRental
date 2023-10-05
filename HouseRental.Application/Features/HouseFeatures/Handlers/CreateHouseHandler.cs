using AutoMapper;
using HouseRental.Application.DTOs.HouseDtos;
using HouseRental.Application.Features.HouseFeatures.Commands;
using HouseRental.Application.Repositories;
using HouseRental.Domain.Entities;
using MediatR;

namespace HouseRental.Application.Features.HouseFeatures.Handlers
{
    public class CreateHouseHandler : IRequestHandler<CreateHouseCommand, HouseGetDto>
    {
        private readonly IHouseRepository _houseRepository;
        private readonly IMapper _mapper;

        public CreateHouseHandler(IHouseRepository houseRepository, IMapper mapper)
        {
            _houseRepository = houseRepository;
            _mapper = mapper;
        }

        public async Task<HouseGetDto> Handle(CreateHouseCommand request, CancellationToken cancellationToken)
        {
            var house = _mapper.Map<House>(request.NewHouseInfo);
            house = await _houseRepository.Add(house);
            return _mapper.Map<HouseGetDto>(house);
        }
    }
}
