using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerPro.Application.Features.Task.Queries.GetAllTasks;

public record GetTasksQuery : IRequest<List<TaskDto>>;

