using MediatR;

namespace HouseRental.Application.Features.HouseFeatures.Commands
{
    public class UpdateHouseCommand : IRequest
    {
        public Guid Id { get; set; }
        public decimal RentalCost { get; set; }
    }
}
