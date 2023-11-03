using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Domain.Common;

namespace TaskManagerPro.Domain.Entities
{
    public class Project : BaseEntity
    {
        public string Name { get; set; }
        public int ManagerId { get; set; }
        public User Manager { get; set; }
        public ICollection<ProjectTask> Tasks { get; set; }
        public bool IsClosed { get; set; }

    }


}
