using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Domain.Common.Enums;

namespace TaskManagerPro.Application.Features.Task.Queries.GetAllTasks
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public StatusOfTask Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public bool IsClosed { get; set; }
    }
}
