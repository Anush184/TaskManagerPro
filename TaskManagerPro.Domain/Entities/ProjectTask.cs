using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using TaskManagerPro.Domain.Common;
using TaskManagerPro.Domain.Common.Enums;
using TaskStatus = TaskManagerPro.Domain.Common.Enums.TaskStatus;

namespace TaskManagerPro.Domain.Entities
{

    public class ProjectTask: BaseEntity
    {
        public string Title { get; set; } 
        public string? Description { get; set; } 
        public string Status { get; set; } 
        public int ProjectId { get; set; } 
        public Project Project { get; set; } 
        public int AssignedToId { get; set; } 
        public User AssignedTo { get; set; } 

        public DateTime? ResolvedAt { get; set; } 
        public ICollection<Comment>? Comments { get; set; } 



}
