using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Core.Exceptions.Abstraction
{
    public class DomainException(string errorMessage, ErrorType errorType = ErrorType.ServerError) : Exception
    {
        public ErrorType ErrorType { get; } = errorType;
        public string ErrorMessage { get; } = errorMessage;
    }

    public enum ErrorType
    {
        NotFound,
        BadRequest,
        Unauthorize,
        ServerError
    }
}