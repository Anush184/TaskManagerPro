using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Features.CustomProject.Queries.GetAllProjects;

namespace TaskManagerPro.Application.Features.CustomComment.Queries.GetAllComments;

public record GetCommentsQuery : IRequest<List<CommentDto>>;
