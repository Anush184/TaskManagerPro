using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using TaskManagerPro.Domain.Common;
using TaskManagerPro.Domain.Common.Enums;

namespace TaskManagerPro.Domain.Entities;


public class ProjectTask : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public StatusOfTask Status { get; set; } = StatusOfTask.NotStarted;
    public int ProjectId { get; set; }
    public Project Project { get; set; } = new Project();
    public int TeamId { get; set; } 
    public Team? Team { get; set; }
    public int AssignedToId { get; set; }
    public User AssignedTo { get; set; } = new User();
    public DateTime? ResolvedAt { get; set; }
    public ICollection<Comment>? Comments { get; set; }

}