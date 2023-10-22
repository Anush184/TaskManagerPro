using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using TaskManagerPro.Domain.Common;
using TaskManagerPro.Domain.Common.Enums;

namespace TaskManagerPro.Domain.Entities;


public class ProjectTask: BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; } = string.Empty;
    public StatusOfTask Status { get; set; }

    public int ProjectId { get; set; }
    public Project Project { get; set; }

    public int? AssigneeId { get; set; }
    public User Assignee { get; set; }

    public ICollection<Comment>? Comments { get; set; }
}
