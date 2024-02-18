using BuberDinner.Application.Common.Errors;
using FluentResults;
using OneOf;

namespace BuberDinner.Application.Services.Authentication
{
    public interface IAuthenticationService
    {
        AuthenticationResult Login(string email, string password);

        //Using OneOf<> Library
        //OneOf<AuthenticationResult, IError> Register(string firstName, string lastName, string email, string password);
        Result<AuthenticationResult> Register(string firstName, string lastName, string email, string password);

    }
}
