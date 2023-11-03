using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Contracts.Persistence;
using TaskManagerPro.Application.Features.Task.Commands.UpdateTask;
using TaskManagerPro.Application.Features.Task.Shared;
using TaskManagerPro.Domain.Common.Enums;

namespace TaskManagerPro.Application.Features.Task.Commands.CreateTask;

public class CreateTaskCommandValidator: AbstractValidator<CreateTaskCommand>
{
    private readonly IProjectRepository _projectRepository;
    private readonly IProjectTaskRepository _taskRepository;

    public CreateTaskCommandValidator(IProjectRepository projectRepository, IProjectTaskRepository projectTaskRepository)
    {
        this._projectRepository = projectRepository;
        this._taskRepository = projectTaskRepository;
        Include(new BaseTaskValidator(_projectRepository, _taskRepository));
    }
}
