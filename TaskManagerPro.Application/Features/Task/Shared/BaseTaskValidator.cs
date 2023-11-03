using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Contracts.Persistence;
using TaskManagerPro.Application.Features.Task.Commands.CreateTask;

namespace TaskManagerPro.Application.Features.Task.Shared
{
    public class BaseTaskValidator : AbstractValidator<BaseTask>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IProjectTaskRepository _taskRepository;
        public BaseTaskValidator(IProjectRepository projectRepository, IProjectTaskRepository projectTaskRepository)
        {
            this._projectRepository = projectRepository;
            this._taskRepository = projectTaskRepository;

            RuleFor(t => t.Title)
            .NotEmpty().WithMessage("{PropertyDescription} is required.")
            .NotNull()
            .MaximumLength(200).WithMessage("{PropertyDescription} must be fewer then 200 characters.");

            RuleFor(t => t.Description)
             .MaximumLength(1000).WithMessage("Task description must not exceed 1000 characters.");

            RuleFor(t => t.ProjectId)
            .NotNull()
            .GreaterThan(0)
            .MustAsync(ProjectMustExist)
            .WithMessage("{PropertyName} does not exist.");

            RuleFor(t => t.AssigneeId)
            .GreaterThanOrEqualTo(0).WithMessage("Invalid Assignee ID. Use 0 for unassigned tasks or a positive integer for assignment.");


            RuleFor(t => t.Status)
            .IsInEnum().WithMessage("Invalid task status.");

            RuleFor(t => t)
                .MustAsync(TaskTitleUnique)
                .WithMessage("Task already exist.");

        }

        private async Task<bool> ProjectMustExist(int id, CancellationToken arg2)
        {
            var project = await _projectRepository.GetByIdAsync(id);
            return project != null;
        }

        private async Task<bool> TaskTitleUnique(BaseTask command, CancellationToken token)
        {
            return await _taskRepository.IsTaskTitleUnique(command.Title);
        }
    }
}
