using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskStatus = TaskManagerPro.Domain.Common.Enums.TaskStatus;

namespace TaskManagerPro.Application.Features.Task.Commands.UpdateTask
{
    public class UpdateTaskCommand: IRequest<Unit>
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime? ResolvedAt { get; set; } 
        public TaskStatus Status { get; set; } 
        public string? AssignedToUserId { get; set; } 
    }
}
