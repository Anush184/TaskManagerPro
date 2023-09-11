using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Domain.Common.Enums;

namespace TaskManagerPro.Application.Features.Task.Commands.UpdateTask;

public class UpdateTaskCommand: IRequest<Unit>
{
    public int TaskId { get; set; } 
    public string Title { get; set; }
    public string? Description { get; set; } 
    public StatusOfTask Status { get; set; } 
    public int ProjectId { get; set; } 
    public int TeamId { get; set; } 
    public int AssignedToId { get; set; } 
    
}
