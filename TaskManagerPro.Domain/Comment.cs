using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Domain.Common;

namespace TaskManagerPro.Domain
{
    public class Comment : BaseEntity
    {
        public string Text { get; set; } = string.Empty;  // Text content of the comment
        public string UserId { get; set; }  // ID of the user who wrote the comment (foreign key to User)
       // public User User { get; set; }  // Navigation property to the user who wrote the comment
        public int TaskId { get; set; }  // ID of the task this comment belongs to (foreign key to Task)
        public Task Task { get; set; }  // Navigation property to the associated task

            
    }
}
