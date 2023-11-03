using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Contracts.Persistence;
using TaskManagerPro.Application.Features.Task.Shared;

namespace TaskManagerPro.Application.Features.Task.Commands.UpdateTask;

public class UpdateTaskCommandValidator: AbstractValidator<UpdateTaskCommand>
{
    private readonly IProjectTaskRepository _taskRepository;
    private readonly IProjectRepository _projectRepository;
    public UpdateTaskCommandValidator(IProjectTaskRepository taskRepository, IProjectRepository projectRepository)
    {
        this._taskRepository = taskRepository;
        this._projectRepository = projectRepository;
        Include(new BaseTaskValidator(_projectRepository, _taskRepository));

        RuleFor(t => t.Id)
            .NotNull()
            .GreaterThan(0)
            .MustAsync(TaskMustExist)
            .WithMessage("{PropertyName} does not exist.");

    }
    private async Task<bool> TaskMustExist(int id, CancellationToken arg2)
    {
        var task = await _taskRepository.GetByIdAsync(id);
        return task != null;
    }

}
