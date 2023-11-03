using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Contracts.Persistence;
using TaskManagerPro.Application.Exceptions;
using TaskManagerPro.Application.Features.CustomProject.Commands.UpdateProject;
using TaskManagerPro.Domain.Entities;

namespace TaskManagerPro.Application.Features.CustomComment.Commands.UpdateComment;

public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly ICommentRepository _commentRepository;
    private readonly IProjectTaskRepository _taskRepository;

    public UpdateCommentCommandHandler(IMapper mapper,
        ICommentRepository commentRepository, IProjectTaskRepository taskRepository)
    {
        this._mapper = mapper;
        this._commentRepository = commentRepository;
        this._taskRepository = taskRepository;
    }
    public async Task<Unit> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
    {

        var validator = new UpdateCommentCommandValidator(_commentRepository,_taskRepository);
        var validatorResult = validator.Validate(request);
        if (validatorResult.Errors.Any())
            throw new BadRequestException("Invalid Comment", validatorResult);

        var comment = await _commentRepository.GetByIdAsync(request.CommentId);
        if (comment is null)
            throw new NotFoundException(nameof(Comment), request.CommentId);

        _mapper.Map(request, comment);

        await _commentRepository.UpdateAsync(comment);
        return Unit.Value;

    }
}

