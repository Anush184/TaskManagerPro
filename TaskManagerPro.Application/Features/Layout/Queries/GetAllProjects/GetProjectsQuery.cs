using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TaskManagerPro.Application.Features.Layout.Queries.GetAllProjects;

public record GetProjectsQuery : IRequest<List<ProjectDto>>;
