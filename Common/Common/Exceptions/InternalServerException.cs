using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Exceptions
{
    public class InternalServerException : Exception
    {
        public InternalServerException(string message) : base(message)
        {
        }

        public InternalServerException(string message, string details) : base(message)
        {
            Details = details;
        }

        public string? Details { get; }
    }
}