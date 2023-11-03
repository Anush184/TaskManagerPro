using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerPro.Application.Features.CustomComment.Commands.UpdateComment;

public class UpdateCommentCommand : IRequest
{
    public int CommentId { get; set; }
    public string Text { get; set; }
    public int TaskId { get; set; }

}

