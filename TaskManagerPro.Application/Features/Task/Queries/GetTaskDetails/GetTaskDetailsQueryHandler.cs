﻿using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Contracts.Persistence;
using TaskManagerPro.Application.Exceptions;
using TaskManagerPro.Domain.Entities;

namespace TaskManagerPro.Application.Features.Task.Queries.GetTaskDetails;

public class GetTaskDetailsQueryHandler: IRequestHandler<GetTaskDetailsQuery, TaskDetailsDto>
{
    private readonly IMapper _mapper;
    private readonly IProjectTaskRepository _taskRepository;

    public GetTaskDetailsQueryHandler(IMapper mapper, IProjectTaskRepository taskRepository)
    {
        this._mapper = mapper;
        this._taskRepository = taskRepository;
    }

    public async Task<TaskDetailsDto> Handle(GetTaskDetailsQuery request, CancellationToken cancellationToken)
    {
        var task = await _taskRepository.GetByIdAsync(request.Id) ?? throw new NotFoundException(nameof(ProjectTask), request.Id);
        var data = _mapper.Map<TaskDetailsDto>(task);
        return data;
    }
}
