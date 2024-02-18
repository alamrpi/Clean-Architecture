using FluentResults;

namespace BuberDinner.Application.Common.Errors
{
    /// <summary>
    /// For Fluent Result Library
    /// </summary>
    public class DuplicateEmailError : IError
    {
        public List<IError> Reasons => throw new NotImplementedException();

        public string Message => throw new NotImplementedException();

        public Dictionary<string, object> Metadata => throw new NotImplementedException();
    }
}
