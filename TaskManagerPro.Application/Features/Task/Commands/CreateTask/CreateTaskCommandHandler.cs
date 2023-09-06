using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Contracts.Persistence;
using TaskManagerPro.Application.Exceptions;

namespace TaskManagerPro.Application.Features.Task.Commands.CreateTask;

public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, int>
{
    private readonly IMapper _mapper;
    private readonly IProjectTaskRepository _taskRepository;

    public CreateTaskCommandHandler(IMapper mapper, IProjectTaskRepository taskRepository)
    {
        this._mapper = mapper;
        this._taskRepository = taskRepository;
    }
    public async Task<int> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        // Validation incoming data
        var validator = new CreateTaskCommandValidator(_taskRepository);
        var validatorResult = await validator.ValidateAsync(request);
        if (validatorResult.Errors.Any())
            throw new BadRequestException("Invalid Task", validatorResult);

        // Convert to domain entity object
        var taskToCreate = _mapper.Map<Domain.Entities.Task>(request);

        //add to database
        await _taskRepository.CreateAsync(taskToCreate);

        // return record id
        return taskToCreate.Id;
    }
}
