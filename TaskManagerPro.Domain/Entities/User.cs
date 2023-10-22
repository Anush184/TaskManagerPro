using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Domain.Common;
using TaskManagerPro.Domain.Common.Enums;

namespace TaskManagerPro.Domain.Entities
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public Role RoleName { get; set; } 
        public ICollection<ProjectTask>? Tasks { get; set; }
        public ICollection<Project>? Projects { get; set; }
    }

}
