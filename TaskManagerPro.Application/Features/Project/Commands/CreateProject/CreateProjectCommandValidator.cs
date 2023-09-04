using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Contracts.Persistence;
using TaskManagerPro.Application.Features.Task.Commands.CreateTask;

namespace TaskManagerPro.Application.Features.Project.Commands.CreateProject
{
    public class CreateProjectCommandValidator: AbstractValidator<CreateProjectCommand>
    {
        private readonly IProjectRepository _projectRepository;

        public CreateProjectCommandValidator(IProjectRepository projectRepository)
        {
            this._projectRepository = projectRepository;
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .MaximumLength(50)
                .WithMessage("{PropertyName} must be fewer than 50 characters.");

            RuleFor(p => p.Description)
                .NotEmpty()
                .WithMessage("{PropertyDescription} is required.")
                .MaximumLength(2000)
                .WithMessage("{PropertyDescription} must be fewer than 2000 characters.");
            RuleFor(p => p.ManagerId)
                .NotEmpty();
            RuleFor(p => p.EndDate)
                .GreaterThanOrEqualTo(p => p.CreatedAt);

            RuleFor(p => p)
                .MustAsync(ProjectDescriptionUnique)
                .WithMessage("Project description already exists.");
        }
        private Task<bool> ProjectDescriptionUnique(CreateProjectCommand command, CancellationToken token)
        {
            return _projectRepository.IsProjectDescriptionUnique(command.Description);
        }


    }
}
