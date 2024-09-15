using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Exceptions.Abstraction;

namespace Core.Exceptions
{
    public class WrongCredentialsException : DomainException
    {
        public WrongCredentialsException() : base("Wrong email or password", ErrorType.BadRequest)
        {

        }

    }
}