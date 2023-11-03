using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Features.CustomComment.Queries.GetAllComments;
using TaskManagerPro.Application.Features.CustomUser.Queries.GetAllUsers;
using TaskManagerPro.Domain.Common.Enums;
using TaskManagerPro.Domain.Entities;

namespace TaskManagerPro.Application.Features.Task.Queries.GetTaskDetails
{
    public class TaskDetailsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public StatusOfTask Status { get; set; }
        public UserDto Assignee { get; set; }
        public List<CommentDto> Comments { get; set; }
    }
}
