using HouseRental.Application.DTOs.HouseDtos;
using MediatR;

namespace HouseRental.Application.Features.HouseFeatures.Queries
{
    public class GetHouseByIdQuery : IRequest<HouseGetDto>
    {
        public Guid Id { get; set; }
    }
}
