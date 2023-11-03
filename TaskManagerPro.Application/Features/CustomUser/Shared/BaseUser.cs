using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Domain.Common.Enums;

namespace TaskManagerPro.Application.Features.CustomUser.Shared
{
    public class BaseUser
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Role RoleName { get; set; }
    }
}
