using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Features.CustomProject.Queries.GetProjectDetails;

namespace TaskManagerPro.Application.Features.CustomComment.Queries.GetCommentDetails
{
    public record GetCommentDetailsQuery(int Id) : IRequest<CommentDetailsDto>;

}
