using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRental.Application.Features.RentalFeatures.Commands
{
    public class CancelRentalCommand : IRequest
    {
        public Guid RentalId { get; set; }
    }
}
