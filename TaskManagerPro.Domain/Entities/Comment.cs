using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Domain.Common;

namespace TaskManagerPro.Domain.Entities
{
    public class Comment: BaseEntity
    {
        public string Text { get; set; } 
        public int UserId { get; set; } 
        public User User { get; set; } 
        public int TaskId { get; set; } 
        public ProjectTask Task { get; set; } 
       
    }

}
