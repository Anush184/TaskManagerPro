using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Domain.Common;

namespace TaskManagerPro.Domain.Entities
{
    public class Comment : BaseEntity
    {
        [Required]
        public string Text { get; set; } = string.Empty;
        public int TaskId { get; set; }
        public ProjectTask Task { get; set; }

        public int TeamMemberId { get; set; }
        public User TeamMember { get; set; }
    }


}
