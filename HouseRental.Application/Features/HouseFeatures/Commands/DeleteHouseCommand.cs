using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRental.Application.Features.HouseFeatures.Commands
{
    public class DeleteHouseCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
