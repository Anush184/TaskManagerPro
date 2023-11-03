using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Features.CustomProject.Shared;
using TaskManagerPro.Domain.Entities;

namespace TaskManagerPro.Application.Features.CustomProject.Commands.CreateProject;

public class CreateProjectCommand: BaseProject, IRequest<int> { }
