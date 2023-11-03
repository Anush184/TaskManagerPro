using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Contracts.Persistence;
using TaskManagerPro.Application.Features.CustomUser.Commands.CreateUser;

namespace TaskManagerPro.Application.Features.CustomUser.Shared
{
    public class BaseUserValidator : AbstractValidator<BaseUser>
    {
        private readonly IUserRepository _userRepository;
        public BaseUserValidator(IUserRepository userRepository) 
        {
            this._userRepository = userRepository;

            RuleFor(u => u.UserName)
                .NotEmpty().WithMessage("User name is required.")
                .MaximumLength(255).WithMessage("User name must not exceed 255 characters.");

            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(u => u.Phone)
                .MaximumLength(15).WithMessage("Phone number must not exceed 15 characters.");

            RuleFor(u => u.RoleName)
                .IsInEnum().WithMessage("Invalid user role.");

            RuleFor(u => u)
                .MustAsync(UserNameUnique)
                .WithMessage("UserName allready exist.");
        }
        private async Task<bool> UserNameUnique(BaseUser command, CancellationToken token)
        {
            return await _userRepository.IsUserNameUnique(command.UserName);
        }

    }
}
