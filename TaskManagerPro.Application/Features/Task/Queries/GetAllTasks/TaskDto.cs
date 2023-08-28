using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerPro.Application.Features.Task.Queries.GetAllTasks
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public TaskStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ProjectId { get; set; }
    }
}
