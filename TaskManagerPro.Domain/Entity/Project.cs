using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Domain.Common;

namespace TaskManagerPro.Domain.Entity
{
    public class Project : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime? EndDate { get; set; }
        public string ManagerId { get; set; }  // ID of the project manager (foreign key to User)
        public User Manager { get; set; }  // Navigation property to the project manager
        public ICollection<Task>? Tasks { get; set; }  // Collection of tasks associated with the project

    }
}
