using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Domain.Entities;

namespace TaskManagerPro.Application.Features.CustomProject.Commands.UpdateProject;

public class UpdateProjectCommand: IRequest<Unit>
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int ManagerId { get; set; }
    public int TeamId { get; set; }

}
