using CuriousCatClone.Application.Features.Commands.User.Login;
using CuriousCatClone.Application.Features.Commands.User.Register;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CuriousCatClone.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterCommandRequest request)
        {
            await _mediator.Send(request);
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommandRequest request)
        {
            LoginCommandResponse result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
