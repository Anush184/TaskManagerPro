using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Contracts.Persistence;

namespace TaskManagerPro.Application.Features.Task.Commands.UpdateTask
{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IProjectTaskRepository _taskRepository;

        public UpdateTaskCommandHandler(IMapper mapper, IProjectTaskRepository taskRepository)
        {
            this._mapper = mapper;
            this._taskRepository = taskRepository;
        }
        public async Task<Unit> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var taskToUpdate =  _mapper.Map<Domain.Entities.Task>(request);
            await _taskRepository.UpdateAsync(taskToUpdate);
            return Unit.Value;
             
        }
    }
}
