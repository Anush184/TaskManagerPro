using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Contracts.Persistence;
using TaskManagerPro.Application.Features.CustomProject.Shared;

namespace TaskManagerPro.Application.Features.CustomProject.Commands.UpdateProject
{
    public class UpdateProjectCommandValidator : AbstractValidator<UpdateProjectCommand>

    {
        private readonly IProjectRepository _projectRepository;
        private readonly IUserRepository _userRepository;

        public UpdateProjectCommandValidator(IProjectRepository projectRepository, IUserRepository userRepository)
        {
            this._projectRepository = projectRepository;
            this._userRepository = userRepository;
            Include(new BaseProjectValidator(_projectRepository, _userRepository));

            RuleFor(p => p.Id)
            .GreaterThan(0).WithMessage("Project ID is required and must be greater than 0.");

        }
            
    }
}
