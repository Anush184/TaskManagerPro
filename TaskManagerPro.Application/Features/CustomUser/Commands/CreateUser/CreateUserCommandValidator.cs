using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Contracts.Persistence;
using TaskManagerPro.Application.Features.CustomUser.Commands.UpdateUser;
using TaskManagerPro.Application.Features.CustomUser.Shared;

namespace TaskManagerPro.Application.Features.CustomUser.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandValidator(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
            Include(new BaseUserValidator(_userRepository));
        }
    }
}
