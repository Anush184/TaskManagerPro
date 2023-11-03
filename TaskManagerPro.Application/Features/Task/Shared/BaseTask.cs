using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Domain.Common.Enums;

namespace TaskManagerPro.Application.Features.Task.Shared
{
    public abstract class BaseTask
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public int ProjectId { get; set; }
        public int? AssigneeId { get; set; }
        public StatusOfTask Status { get; set; } = StatusOfTask.NotStarted;
    }
}
