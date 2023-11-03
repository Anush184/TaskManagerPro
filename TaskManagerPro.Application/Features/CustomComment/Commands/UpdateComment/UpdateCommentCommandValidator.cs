using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Contracts.Persistence;

namespace TaskManagerPro.Application.Features.CustomComment.Commands.UpdateComment;

public class UpdateCommentCommandValidator : AbstractValidator<UpdateCommentCommand>
{
    private readonly ICommentRepository _commentRepository;
    private readonly IProjectTaskRepository _taskRepository;

    public UpdateCommentCommandValidator(ICommentRepository commentRepository, IProjectTaskRepository taskRepository)
    {
        this._commentRepository = commentRepository;
        this._taskRepository = taskRepository;
        RuleFor(c => c.CommentId)
            .GreaterThan(0).WithMessage("Invalid comment ID.");

        RuleFor(c => c.Text)
            .NotEmpty().WithMessage("New comment text is required.")
            .MaximumLength(255).WithMessage("New comment text must not exceed 255 characters.");

        RuleFor(c => c.TaskId)
            .NotNull()
            .GreaterThan(0).WithMessage("Invalid task ID.")
            .MustAsync(TaskMustExist)
            .WithMessage("{PropertyName} does not exist.");

        RuleFor(c => c.CommentId)
            .NotNull()
            .GreaterThan(0)
            .MustAsync(CommentMustExist)
            .WithMessage("{PropertyName} does not exist.");
    }
    private async Task<bool> TaskMustExist(int id, CancellationToken arg2)
    {
        var task = await _taskRepository.GetByIdAsync(id);
        return task != null;
    }

    private async Task<bool> CommentMustExist(int id, CancellationToken arg2)
    {
        var task = await _commentRepository.GetByIdAsync(id);
        return task != null;
    }
}
