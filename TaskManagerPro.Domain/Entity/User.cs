using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Domain.Common;

namespace TaskManagerPro.Domain.Entity
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }  // First name of the user
        public string LastName { get; set; }  // Last name of the user
        public string Email { get; set; }  // Email address of the user
        public string PasswordHash { get; set; }  // Hashed password of the user
        public DateTime DateOfBirth { get; set; }  // Date of birth of the user
        public bool IsLocked { get; set; }  // Flag indicating if the user account is locked

    }
}
