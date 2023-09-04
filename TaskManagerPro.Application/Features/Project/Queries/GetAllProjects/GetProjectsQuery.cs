using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Features.Task.Queries.GetAllTasks;

namespace TaskManagerPro.Application.Features.Project.Queries.GetAllProjects;

public record GetProjectsQuery : IRequest<List<ProjectDto>>;
