using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Domain.Common;
using TaskManagerPro.Domain.Common.Enums;

namespace TaskManagerPro.Domain.Entities
{
    public class User : BaseEntity
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [MaxLength(255)]
        [RegularExpression(@"^.*@.*$")]
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public Role RoleName { get; set; } 
        public ICollection<ProjectTask>? Tasks { get; set; }
        public ICollection<Project>? Projects { get; set; }
        public ICollection<Comment>? Comments { get; set; }
    }

}
