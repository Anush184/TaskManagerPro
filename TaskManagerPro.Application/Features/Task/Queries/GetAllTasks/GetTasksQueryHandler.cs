using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Contracts.Persistence;

namespace TaskManagerPro.Application.Features.Task.Queries.GetAllTasks
{
    public class GetTasksQueryHandler : IRequestHandler<GetTasksQuery, List<TaskDto>>
    {
        private readonly IMapper _mapper;
        private readonly ITaskRepository _taskRepository;

        public GetTasksQueryHandler(IMapper mapper, ITaskRepository taskRepository)
        {
            this._mapper = mapper;
            this._taskRepository = taskRepository;
        }
        public async Task<List<TaskDto>> Handle(GetTasksQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var tasks = await _taskRepository.GetAsync();
            //Convert data objects to DTO objects
            var data = _mapper.Map<List<TaskDto>>(tasks);
            //return list of DTO object
            return data;
        }
    }
}
