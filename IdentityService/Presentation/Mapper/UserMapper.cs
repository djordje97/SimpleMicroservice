using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Core.Entities;
using Presentation.Contracts.User;

namespace Presentation.Mapper
{
    public static class UserMapper
    {

        public static RegisterUserCommand ToCommand(this RegisterUserRequest request)
        {
            return new RegisterUserCommand(request.Name, request.LastName, request.Email, request.Password);
        }

        public static RegisterUserResponse ToApiResponse(this User user)
        {
            return new RegisterUserResponse
            {
                Id = user.Id,
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email,
            };
        }

        public static LoginUserCommand ToCommand(this LoginUserRequest request) => new LoginUserCommand(request.Email, request.Password);

        public static LoginUserResponse ToApiResponse(this TokenResponse tokenResponse) => new LoginUserResponse(tokenResponse.AccessToken, tokenResponse.RefreshToken);
    }
}