using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Contracts.Persistence;

namespace TaskManagerPro.Application.Features.CustomComment.Commands.CreateComment;

public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
{
    private readonly ICommentRepository _commentRepository;
    private readonly IProjectTaskRepository _taskRepository;
    private readonly IUserRepository _userRepository;

    public CreateCommentCommandValidator(ICommentRepository commentRepository,
        IProjectTaskRepository taskRepository, IUserRepository userRepository)
    {
        this._commentRepository = commentRepository;
        this._taskRepository = taskRepository;
        this._userRepository = userRepository;
        RuleFor(c => c.Text)
            .NotEmpty().WithMessage("Comment text is required.")
            .MaximumLength(255).WithMessage("Comment text must not exceed 255 characters.");

       RuleFor(c => c.TeamMemberId)
            .NotNull()
            .GreaterThan(0).WithMessage("Invalid team member ID.")
            .MustAsync(TeamMemberMustExist)
            .WithMessage("{PropertyName} does not exist.");

        RuleFor(c => c.TaskId)
            .NotNull()
            .GreaterThan(0).WithMessage("Invalid task ID.")
            .MustAsync(TaskMustExist)
            .WithMessage("{PropertyName} does not exist.");
        
    }

    private async Task<bool> TaskMustExist(int id, CancellationToken arg2)
    {
        var task = await _taskRepository.GetByIdAsync(id);
        return task != null;
    }

    private async Task<bool> TeamMemberMustExist(int id, CancellationToken arg2)
    {
        var user = await _userRepository.GetByIdAsync(id);
        return user != null;
    }
}
