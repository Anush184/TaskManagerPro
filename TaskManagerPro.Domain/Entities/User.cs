using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Domain.Common;

namespace TaskManagerPro.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; } 
        public string PasswordHash { get; set; }
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public string Role { get; set; } 
        public ICollection<Team>? Teams { get; set; }

        public string? Email { get; set; } 
        public string? Phone { get; set; }

    }
}
