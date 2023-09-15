using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Contracts.Persistence;


namespace TaskManagerPro.Application.Features.CustomProject.Commands.CreateProject
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
           
            RuleFor(p => p)
                .MustAsync(ProjectNameUnique)
                .WithMessage("Project name already exists.");
        }
        private Task<bool> ProjectNameUnique(CreateProjectCommand command, CancellationToken token)
        {
            return _projectRepository.IsProjectNameUnique(command.Name);
        }


    }
}
