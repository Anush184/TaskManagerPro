using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using TaskManagerPro.Domain.Common;



namespace TaskManagerPro.Domain
{

    public class Task: BaseEntity
    {
        public string Description { get; set; }  // Description of the task
        public TaskStatus Status { get; set; }  // Status of the task (enum: InProgress, Resolved, etc.)
        public DateTime? ResolvedAt { get; set; }  // Date and time the task was resolved (nullable)
        public int ProjectId { get; set; }  // ID of the project this task belongs to (foreign key to Project)
        public Project Project { get; set; }  // Navigation property to the associated project
        public string AssignedToUserId { get; set; }  // ID of the user the task is assigned to (foreign key to User)
        public User AssignedToUser { get; set; }  // Navigation property to the assigned user
        public ICollection<Comment>? Comments { get; set; }  // Collection of comments related to the task

    }

    public enum TaskStatus
    {
        NotStarted,
        InProgress,
        Completed,
        OnHold,
        Cancelled,
        Deferred
    }
}
