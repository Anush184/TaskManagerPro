using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Features.CustomUser.Queries.GetAllUsers;

namespace TaskManagerPro.Application.Features.CustomComment.Queries.GetAllComments
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public UserDto TeamMember { get; set; }
    }
}
