using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskStatus = TaskManagerPro.Domain.Common.Enums.TaskStatus;

namespace TaskManagerPro.Application.Features.Task.Queries.GetTaskDetails
{
    public class TaskDetailsDto
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public TaskStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ResolvedAt { get; set; }
        public int ProjectId { get; set; }
        public Domain.Entities.Project Project { get; set; }  // Include a ProjectDto for more details
    }
}
