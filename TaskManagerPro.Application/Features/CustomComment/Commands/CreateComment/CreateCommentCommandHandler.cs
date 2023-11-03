using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Contracts.Persistence;
using TaskManagerPro.Application.Exceptions;
using TaskManagerPro.Application.Features.Task.Commands.CreateTask;
using TaskManagerPro.Domain.Entities;

namespace TaskManagerPro.Application.Features.CustomComment.Commands.CreateComment;

public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, int>
{
    private readonly IMapper _mapper;
    private readonly ICommentRepository _commentRepository;
    private readonly IProjectTaskRepository _taskRepository;
    private readonly IUserRepository _userRepository;

    public CreateCommentCommandHandler(IMapper mapper, 
        ICommentRepository commentRepository, IProjectTaskRepository taskRepository, IUserRepository userRepository)
    {
        this._mapper = mapper;
        this._commentRepository = commentRepository;
        this._taskRepository = taskRepository;
        this._userRepository = userRepository;
    }
    public async Task<int> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {

        var validator = new CreateCommentCommandValidator(_commentRepository, _taskRepository, _userRepository);
        var validatorResult = await validator.ValidateAsync(request);
        if (validatorResult.Errors.Any())
            throw new BadRequestException("Invalid Comment", validatorResult);


        var commentToCreate = _mapper.Map<Comment>(request);

        await _commentRepository.CreateAsync(commentToCreate);

        return commentToCreate.Id;
    }
}

