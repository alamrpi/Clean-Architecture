using BuberDinner.Application.Services.Authentication;
using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            this._authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public ActionResult<AuthenticationResponse> Register(RegisterRequest request)
        {
            var result = _authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);

            return Ok(MapAuthResult(result));
        }

        private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
        {
            return new AuthenticationResponse(authResult.User.Id, authResult.User.FirstName, authResult.User.LastName, authResult.User.Email, authResult.Token);
        }
        [HttpPost("login")]
        public ActionResult<AuthenticationResponse> Login(LoginRequest request)
        {

            var result = _authenticationService.Login(request.Email, request.Password);
            return Ok(new AuthenticationResponse(result.User.Id, result.User.FirstName, result.User.LastName, result.User.Email, result.Token));
        }
    }
}
