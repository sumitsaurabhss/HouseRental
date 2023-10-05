using AutoMapper;
using HouseRental.Application.DTOs.HouseDtos;
using HouseRental.Application.Features.HouseFeatures.Queries;
using HouseRental.Application.Repositories;
using MediatR;

namespace HouseRental.Application.Features.HouseFeatures.Handlers
{
    public class GetAllHousesHandler : IRequestHandler<GetAllHousesQuery, List<HouseGetDto>>
    {
        private readonly IHouseRepository _houseRepository;
        private readonly IMapper _mapper;

        public GetAllHousesHandler(IHouseRepository houseRepository, IMapper mapper)
        {
            _houseRepository = houseRepository;
            _mapper = mapper;
        }

        public async Task<List<HouseGetDto>> Handle(GetAllHousesQuery request, CancellationToken cancellationToken)
        {
            var houses = await _houseRepository.GetAll();
            return _mapper.Map<List<HouseGetDto>>(houses);
        }
    }
}
