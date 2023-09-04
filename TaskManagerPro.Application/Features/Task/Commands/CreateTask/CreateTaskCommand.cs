using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskStatus = TaskManagerPro.Domain.Common.Enums.TaskStatus;

namespace TaskManagerPro.Application.Features.Task.Commands.CreateTask
{
    public class CreateTaskCommand : IRequest<int>
    {

        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;  // Date and time the entity was created
        public TaskStatus Status { get; set; } = TaskStatus.NotStarted;  // Status of the task (enum: InProgress, Resolved, etc.)
        public int ProjectId { get; set; }  // ID of the project this task belongs to (foreign key to Project)
        public string? AssignedToUserId { get; set; }  //  user assigned to the task (optional)
    }
}
