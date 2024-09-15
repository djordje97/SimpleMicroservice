using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Core.Exceptions.Abstraction;

namespace Core.Exceptions
{
    public class UserAlreadyExistException : DomainException
    {
        public UserAlreadyExistException() : base("User with provided email already exists.", ErrorType.BadRequest)
        {

        }

    }
}