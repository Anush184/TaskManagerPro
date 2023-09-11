using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Domain.Common;

namespace TaskManagerPro.Domain.Entities
{
    public class Project: BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } 
        public int ManagerId { get; set; } 
        public User Manager { get; set; } = new User();
        public int TeamId { get; set; } 
        public Team? Team { get; set; }
        public ICollection<ProjectTask>? Tasks { get; set; } 

    }

}
