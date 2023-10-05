using HouseRental.Application.DTOs.HouseDtos;
using MediatR;

namespace HouseRental.Application.Features.HouseFeatures.Queries
{
    public class GetAllHousesQuery : IRequest<List<HouseGetDto>>
    {
    }
}
