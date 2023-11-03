using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Contracts.Persistence;
using TaskManagerPro.Application.Features.Task.Shared;

namespace TaskManagerPro.Application.Features.CustomProject.Shared
{
    public class BaseProjectValidator: AbstractValidator<BaseProject>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IUserRepository _userRepository;
        public BaseProjectValidator(IProjectRepository projectRepository, IUserRepository userRepository) 
        {
            this._projectRepository = projectRepository;
            this._userRepository = userRepository;

            RuleFor(p => p.Name)
           .NotEmpty().WithMessage("Project name is required.")
           .MaximumLength(255).WithMessage("Project name must not exceed 255 characters.");
           
           RuleFor(p => p)
                .MustAsync(ProjectNameUnique)
                .WithMessage("Project already exist.");

            RuleFor(p => p.ManagerId)
                .NotNull()
                .GreaterThan(0).WithMessage("Manager ID is required and must be greater than 0.")
                .MustAsync(ManagerMustExist)
                .WithMessage("{PropertyName} must be exist.");
        }
        private async Task<bool> ManagerMustExist(int id, CancellationToken token)
        {
            var manager = await _userRepository.GetByIdAsync(id);
            return manager != null;
        }

        private async Task<bool> ProjectNameUnique(BaseProject command, CancellationToken token)
        {
            return await _projectRepository.IsProjectNameUnique(command.Name);
        }
    }
    
}
