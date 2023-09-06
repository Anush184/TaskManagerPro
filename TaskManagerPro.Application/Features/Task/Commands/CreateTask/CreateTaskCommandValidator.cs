using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Contracts.Persistence;

namespace TaskManagerPro.Application.Features.Task.Commands.CreateTask
{
    public class CreateTaskCommandValidator: AbstractValidator<CreateTaskCommand>
    {
        private readonly IProjectTaskRepository _taskRepository;

        public CreateTaskCommandValidator(IProjectTaskRepository taskRepository)
        {
            this._taskRepository = taskRepository;
            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("{PropertyDescription} is required.")
                .NotNull()
                .MaximumLength(1000).WithMessage("{PropertyDescription} must be fewer than 1000 characters.");

            RuleFor(p => p.Status)
                .NotEmpty().WithMessage("{PropertyStatus} is required.")
                .NotNull();

            RuleFor(p => p.ProjectId)
                .NotNull();

            RuleFor(p => p)
                .MustAsync(TaskDescriptionUnique)
                .WithMessage("Task description already exists.");
         
        }

        private Task<bool> TaskDescriptionUnique(CreateTaskCommand command, CancellationToken token)
        {
            return _taskRepository.IsTaskDescriptionUnique(command.Description);
        }
    }
}
