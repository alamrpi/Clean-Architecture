using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistance;
using BuberDinner.Application.Services.Authentication.Common;
using BuberDinner.Domain.Entities;
using ErrorOr;
using MediatR;
using BuberDinner.Domain.Errors;
using BuberDinner.Application.Authentication.Queries.Login;

namespace BuberDinner.Application.Authentication.Commands.Register
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
        {
            this._userRepository = userRepository;
            this._jwtTokenGenerator = jwtTokenGenerator;
        }
        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {

            if (_userRepository.GetUserByEmail(query.Email) is not User user)
                return Errors.Authentication.InvalidCredentials;

            if (query.Password != user.Password)
                return Errors.Authentication.InvalidCredentials;

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }
    }
}
