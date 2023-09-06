using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Contracts.Persistence;
using TaskManagerPro.Application.Exceptions;

namespace TaskManagerPro.Application.Features.Task.Commands.DeleteTask
{
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
                throw new NotFoundException(nameof(Domain.Entities.Task), request.Id);

            await _taskRepository.DeleteAsync(taskToDelete);
            return Unit.Value;

        }
    }
}
