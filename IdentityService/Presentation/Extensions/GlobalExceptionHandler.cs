using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Core.Exceptions.Abstraction;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Namotion.Reflection;

namespace Presentation.Extensions
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var problemDetails = exception switch
            {
                DomainException de when de.ErrorType == ErrorType.BadRequest => new ProblemDetails
                {
                    Title = "Bad Request",
                    Detail = de.ErrorMessage,
                    Status = StatusCodes.Status400BadRequest,
                },

                DomainException de when de.ErrorType == ErrorType.NotFound => new ProblemDetails
                {
                    Title = "Not Found",
                    Detail = de.ErrorMessage,
                    Status = StatusCodes.Status404NotFound,
                },

                DomainException de when de.ErrorType == ErrorType.Unauthorize => new ProblemDetails
                {
                    Title = "UnAuthorized",
                    Detail = de.ErrorMessage,
                    Status = StatusCodes.Status401Unauthorized,
                },
                _ => new ProblemDetails
                {
                    Title = "Server Error",
                    Detail = exception.Message,
                    Status = StatusCodes.Status500InternalServerError,
                }
            };

            httpContext.Response.StatusCode = problemDetails.Status.Value;
            await httpContext.Response.WriteAsJsonAsync(problemDetails);
            return true;
        }
    }
}