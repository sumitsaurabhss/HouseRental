using HouseRental.Application.DTOs.UserDtos;
using HouseRental.Application.Features.UserFeatures.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HouseRental.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // POST: api/users/signup
        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] UserRegisterDto registerInfo)
        {
            var user = await _mediator.Send(new RegisterUserCommand { RegisterInfo = registerInfo });
            return Ok(user);
        }

        // POST: api/users/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto credentials)
        {
            var user = await _mediator.Send(new LoginUserCommand { Credentials = credentials });
            return Ok(user);
        }
    }
}
