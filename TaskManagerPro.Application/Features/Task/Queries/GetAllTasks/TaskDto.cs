using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerPro.Application.Features.Task.Queries.GetAllTasks
{
    public class TaskDto
    {
        public int Id { get; set; }  // Unique identifier for the task
        public string Description { get; set; } = string.Empty;  // Description of the task
        public TaskStatus Status { get; set; }  // Status of the task
        public DateTime CreatedAt { get; set; }  // Date and time the task was created
        public DateTime? ResolvedAt { get; set; }  // Date and time the task was resolved (nullable)
        public int ProjectId { get; set; }  // ID of the project this task belongs to

    }
}
