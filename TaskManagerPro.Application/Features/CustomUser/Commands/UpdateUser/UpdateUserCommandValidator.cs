using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Contracts.Persistence;
using TaskManagerPro.Application.Features.CustomUser.Shared;

namespace TaskManagerPro.Application.Features.CustomUser.Commands.UpdateUser
{
   public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandValidator(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
            Include(new BaseUserValidator(_userRepository));

            RuleFor(u => u.UserId)
                .NotNull()
                .GreaterThan(0).WithMessage("User ID is required and must be greater than 0.")
                .MustAsync(UserMustExist)
                .WithMessage("{PropertyName} must be exist.");

            
        }
        private async Task<bool> UserMustExist(int id, CancellationToken token)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return user != null;
        }
    }
}
