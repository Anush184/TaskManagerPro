using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Domain.Common.Enums;
using TaskManagerPro.Domain.Entities;

namespace TaskManagerPro.Application.Features.Task.Queries.GetTaskDetails
{
    public class TaskDetailsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; } = string.Empty;
        public StatusOfTask Status { get; set; }
        public int ProjectId { get; set; }
        public int TeamId { get; set; }
        public int AssignedToId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ResolvedAt { get; set; }
        public bool IsClosed { get; set; }
        
    }
}
