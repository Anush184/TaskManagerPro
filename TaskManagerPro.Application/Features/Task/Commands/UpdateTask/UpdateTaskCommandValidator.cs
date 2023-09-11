using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Contracts.Persistence;


namespace TaskManagerPro.Application.Features.Task.Commands.UpdateTask;

public class UpdateTaskCommandValidator: AbstractValidator<UpdateTaskCommand>
{
    private readonly IProjectTaskRepository _taskRepository;
    public UpdateTaskCommandValidator(IProjectTaskRepository taskRepository)
    {
            this._taskRepository = taskRepository;

        RuleFor(p => p.Description)
            .NotEmpty().WithMessage("{PropertyDescription} is required")
            .NotNull()
            .MaximumLength(1000).WithMessage("{PropertyDescription} must be fewer than 1000 characters");

        RuleFor(p => p.Status)
            .NotEmpty().WithMessage("{PropertyStatus} is required")
            .NotNull();
        RuleFor(q => q)
            .MustAsync(TaskDescriptionUnique)
            .WithMessage("Task description already exists");

    }

    private Task<bool> TaskDescriptionUnique(UpdateTaskCommand command, CancellationToken token)
    {
        return _taskRepository.IsTaskTitleUnique(command.Title);
    }

    
}
