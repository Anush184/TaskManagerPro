using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Domain.Common;

namespace TaskManagerPro.Domain.Entities
{
    public class Team: BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<User>? Members { get; set; }
        public ICollection<Project>? Projects { get; set; }
    }
}
