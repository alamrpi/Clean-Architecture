using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Application.Services.Authentication.Common;
using BuberDinner.Contracts.Authentication;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthenticationController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public AuthenticationController(ISender mediator, IMapper mapper)
        {
            this._mediator = mediator;
            this._mapper = mapper;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = _mapper.Map<RegisterCommand>(request);

            var result = await _mediator.Send(command);

            return result.Match(
                    authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                    Problem
                );
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = _mapper.Map<LoginQuery>(request);

            var result = await _mediator.Send(query);
            return result.Match(
                   authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                   Problem
               );
        }
    }
}
