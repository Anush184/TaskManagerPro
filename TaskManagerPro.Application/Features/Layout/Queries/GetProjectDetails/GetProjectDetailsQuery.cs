using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TaskManagerPro.Application.Features.Layout.Queries.GetProjectDetails;

public record GetProjectDetailsQuery(int Id) : IRequest<ProjectDetailsDto>;
