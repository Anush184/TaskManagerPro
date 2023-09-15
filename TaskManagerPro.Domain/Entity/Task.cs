using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using TaskManagerPro.Domain.Common;
using TaskManagerPro.Domain.Common.Enums;
using TaskStatus = TaskManagerPro.Domain.Common.Enums.TaskStatus;

namespace TaskManagerPro.Domain.Entity
{

    public class Task : BaseEntity
    {
        public string Description { get; set; } = string.Empty;  // Description of the task
        public TaskStatus Status { get; set; }  // Status of the task (enum: InProgress, Resolved, etc.)
        public DateTime? ResolvedAt { get; set; }  // Date and time the task was resolved (nullable)
        public int ProjectId { get; set; }  // ID of the project this task belongs to (foreign key to Project)
        public Project Project { get; set; }  // Navigation property to the associated project
        public string AssignedToUserId { get; set; } = string.Empty; // ID of the user the task is assigned to (foreign key to User)
        public User? AssignedToUser { get; set; }  // Navigation property to the assigned user
        public ICollection<Comment>? Comments { get; set; }  // Collection of comments related to the task

    }


}
