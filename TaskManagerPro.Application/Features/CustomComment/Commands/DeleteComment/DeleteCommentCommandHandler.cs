using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Contracts.Persistence;
using TaskManagerPro.Application.Exceptions;
using TaskManagerPro.Application.Features.CustomPrject.Commands.DeleteProject;
using TaskManagerPro.Domain.Entities;

namespace TaskManagerPro.Application.Features.CustomComment.Commands.DeleteComment;

public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, Unit>
{
    private readonly ICommentRepository _commentRepository;

    public DeleteCommentCommandHandler(ICommentRepository commentRepository)
    {
        this._commentRepository = commentRepository;
    }

    public async Task<Unit> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
    {
        var commentToDelete = await _commentRepository.GetByIdAsync(request.CommentId);
        if (commentToDelete == null)
            throw new NotFoundException(nameof(Project), request.CommentId);

        await _commentRepository.DeleteAsync(commentToDelete);
        return Unit.Value;
    }
}
