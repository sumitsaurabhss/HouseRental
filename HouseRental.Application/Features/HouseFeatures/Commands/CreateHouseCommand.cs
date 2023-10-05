using HouseRental.Application.DTOs.HouseDtos;
using MediatR;

namespace HouseRental.Application.Features.HouseFeatures.Commands
{
    public class CreateHouseCommand : IRequest<HouseGetDto>
    {
        public HouseCreateDto NewHouseInfo { get; set; } = null!;
    }
}
