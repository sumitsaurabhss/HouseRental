using MediatR;

namespace HouseRental.Application.Features.RentalFeatures.Commands
{
    public class DeleteRentalCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
