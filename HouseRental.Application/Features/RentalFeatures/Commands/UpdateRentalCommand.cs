using MediatR;

namespace HouseRental.Application.Features.RentalFeatures.Commands
{
    public class UpdateRentalCommand : IRequest
    {
        public Guid Id { get; set; }
        public int Duration { get; set; }
    }
}
