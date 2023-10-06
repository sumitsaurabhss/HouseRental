using HouseRental.Application.DTOs.RentalDtos;
using HouseRental.Application.Features.RentalFeatures.Commands;
using HouseRental.Application.Features.RentalFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace HouseRental.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RentalsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET: api/<RentalsController>
        [HttpGet("all")]
        public async Task<ActionResult<List<RentalGetDtoForAdmin>>> GetAllRentals()
        {
            var rentals = await _mediator.Send(new GetAllRentalsQuery());
            return Ok(rentals);
        }


        //changed. Make a change conforming to it in Angulr services.
        [HttpGet("all/{userId}")]
        public async Task<ActionResult<List<RentalGetDtoForUser>>> GetAllRentalsByUserId(Guid userId)
        {
            var rentals = await _mediator.Send(new GetAllRentalsByUserIdQuery { UserId = userId });
            return Ok(rentals);
        }

        // GET api/<RentalsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RentalGetDtoForUser>> GetRentalByIdAsync(Guid id)
        {
            var rental = await _mediator.Send(new GetRentalByIdQuery { Id = id });
            return Ok(rental);
        }

        // POST api/<RentalsController>
        [HttpPost("add")]
        public async Task<ActionResult> PostAsync([FromBody] RentalCreateDto rental)
        {
            var command = new CreateRentalCommand { RentalInfo = rental };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<RentalsController>/5
        [HttpPut("update/{id}")]
        public async Task<ActionResult> UpdateRental(Guid id, [FromBody] int duration)
        {
            var command = new UpdateRentalCommand { Id = id, Duration = duration };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPatch("return/{rentalId}")]
        public async Task<ActionResult> RequestForReturn(Guid rentalId, [FromBody] JsonPatchDocument<RentalGetDtoForUser> patchDocument)
        {
            var command = new CancelRentalCommand { RentalId = rentalId };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<RentalsController>/5
        [HttpDelete("validate/{id}")]
        public async Task<ActionResult> ValidateReturn(Guid id)
        {
            var command = new DeleteRentalCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
