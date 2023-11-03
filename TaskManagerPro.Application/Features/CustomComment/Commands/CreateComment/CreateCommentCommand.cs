using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerPro.Application.Features.CustomComment.Commands.CreateComment;

public class CreateCommentCommand : IRequest<int>
{
    public string Text { get; set; }
    public int TaskId { get; set; }
    public int TeamMemberId { get; set; }
}

