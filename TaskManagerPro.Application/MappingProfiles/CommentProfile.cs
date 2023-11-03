using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Features.CustomComment.Commands.CreateComment;
using TaskManagerPro.Application.Features.CustomComment.Commands.UpdateComment;
using TaskManagerPro.Application.Features.CustomComment.Queries.GetAllComments;
using TaskManagerPro.Application.Features.CustomComment.Queries.GetCommentDetails;
using TaskManagerPro.Application.Features.CustomUser.Commands.CreateUser;
using TaskManagerPro.Domain.Entities;

namespace TaskManagerPro.Application.MappingProfiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        { 
            CreateMap<CommentDto, Comment>().ReverseMap();
            CreateMap<Comment, CommentDetailsDto>().ReverseMap();
            CreateMap<CreateCommentCommand, Comment>();
            CreateMap<UpdateCommentCommand, Comment>();
        }
  
    }
}
