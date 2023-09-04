using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Features.Task.Queries.GetTaskDetails;

namespace TaskManagerPro.Application.Features.Project.Queries.GetProjectDetails;

public record GetProjectDetailsQuery(int Id) : IRequest<ProjectDetailsDto>;
