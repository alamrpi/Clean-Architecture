using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Application.Common.Errors
{
    /// <summary>
    /// For OneOf<> Library
    /// </summary>
    //public record struct DuplicateEmailError : IError
    //{
    //    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;

    //    public string ErrorMessage => "Email already exists";
    //}


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
