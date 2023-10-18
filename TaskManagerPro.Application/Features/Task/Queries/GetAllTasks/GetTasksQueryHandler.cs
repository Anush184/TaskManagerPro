using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Contracts.Logging;
using TaskManagerPro.Application.Contracts.Persistence;

namespace TaskManagerPro.Application.Features.Task.Queries.GetAllTasks
{
    public class GetTasksQueryHandler : IRequestHandler<GetTasksQuery, List<TaskDto>>
    {
        private readonly IMapper _mapper;
        private readonly IProjectTaskRepository _taskRepository;
        private readonly IAppLogger<GetTasksQueryHandler> _logger;

        public GetTasksQueryHandler(IMapper mapper, IProjectTaskRepository taskRepository,
            IAppLogger<GetTasksQueryHandler> logger)
        {
            this._mapper = mapper;
            this._taskRepository = taskRepository;
            this._logger = logger;
        }
        public async Task<List<TaskDto>> Handle(GetTasksQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _taskRepository.GetAsync();
            var data = _mapper.Map<List<TaskDto>>(tasks);
            _logger.LogInformation("Tasks were retrieved successfully.");
            return data;
        }
    }
}
