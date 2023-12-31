﻿using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Contracts.Persistence;
using TaskManagerPro.Application.Exceptions;
using TaskManagerPro.Application.Features.Task.Commands.CreateTask;
using TaskManagerPro.Domain.Entities;

namespace TaskManagerPro.Application.Features.Task.Commands.DeleteTask;

public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, Unit>
{
   private readonly IProjectTaskRepository _taskRepository;
   public DeleteTaskCommandHandler(IProjectTaskRepository taskRepository)
    {
       this._taskRepository = taskRepository;
    }
    public async Task<Unit> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
               
        var taskToDelete = await _taskRepository.GetByIdAsync(request.Id);
        if (taskToDelete == null)
            throw new NotFoundException(nameof(ProjectTask), request.Id);

        await _taskRepository.DeleteAsync(taskToDelete);
        return Unit.Value;

    }
}
