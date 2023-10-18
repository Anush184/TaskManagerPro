using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Contracts.Logging;
using TaskManagerPro.Application.Contracts.Persistence;
using TaskManagerPro.Application.Exceptions;
using TaskManagerPro.Domain.Entities;

namespace TaskManagerPro.Application.Features.Task.Commands.UpdateTask;

public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IProjectTaskRepository _taskRepository;
    private readonly IAppLogger<UpdateTaskCommandHandler> _logger;

    public UpdateTaskCommandHandler(IMapper mapper, IProjectTaskRepository taskRepository,
        IAppLogger<UpdateTaskCommandHandler> logger)
    {
        this._mapper = mapper;
        this._taskRepository = taskRepository;
        this._logger = logger;
    }
    public async Task<Unit> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateTaskCommandValidator(_taskRepository);
        var validationResult = validator.ValidateAsync(request);
        if(validationResult.Result.Errors.Any())
        { 
            _logger.LogWorning("Validation errors in update request for {0} - {1}", nameof(ProjectTask), request.TaskId);
            throw new BadRequestException("Invalid Task", validationResult.Result);
        }
        var taskToUpdate =  _mapper.Map<ProjectTask>(request);
        await _taskRepository.UpdateAsync(taskToUpdate);
        return Unit.Value;
         
    }
}
