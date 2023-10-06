using HouseRental.Application.DTOs.HouseDtos;
using HouseRental.Application.Features.HouseFeatures.Commands;
using HouseRental.Application.Features.HouseFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HouseRental.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HousesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HousesController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET: api/<housesController>
        [HttpGet]
        public async Task<ActionResult<List<HouseGetDto>>> GetAllhouses()
        {
            var houses = await _mediator.Send(new GetAllHousesQuery());
            return Ok(houses);
        }

        // GET api/<housesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HouseGetDto>> GethouseById(Guid id)
        {
            var house = await _mediator.Send(new GetHouseByIdQuery { Id = id });
            return Ok(house);
        }

        // POST api/<housesController>
        [HttpPost("add")]
        public async Task<ActionResult> Addhouse([FromBody] HouseCreateDto house)
        {
            var command = new CreateHouseCommand { NewHouseInfo = house };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<housesController>
        [HttpPut("update/{id}")]
        public async Task<ActionResult> Updatehouse(Guid id, [FromBody] decimal rentalCost)
        {
            var command = new UpdateHouseCommand { Id = id, RentalCost = rentalCost };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<housesController>/5
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> Deletehouse(Guid id)
        {
            var command = new DeleteHouseCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
