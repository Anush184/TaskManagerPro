using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Features.CustomComment.Queries.GetAllComments;
using TaskManagerPro.Application.Features.CustomProject.Queries.GetProjectDetails;
using TaskManagerPro.Application.Features.Task.Queries.GetTaskDetails;
using TaskManagerPro.Domain.Common.Enums;

namespace TaskManagerPro.Application.Features.CustomUser.Queries.GetUserDetails
{
    public class UserDetailsDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Role RoleName { get; set; }
        public List<ProjectDetailsDto> Projects { get; set; }
        public List<TaskDetailsDto> Tasks { get; set; }
        public List<CommentDto> Comments { get; set; }
    }
}
