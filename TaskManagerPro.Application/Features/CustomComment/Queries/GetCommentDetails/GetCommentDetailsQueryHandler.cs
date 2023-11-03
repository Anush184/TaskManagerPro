using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Contracts.Persistence;
using TaskManagerPro.Application.Exceptions;
using TaskManagerPro.Application.Features.CustomProject.Queries.GetProjectDetails;
using TaskManagerPro.Domain.Entities;

namespace TaskManagerPro.Application.Features.CustomComment.Queries.GetCommentDetails
{
    public class GetCommentDetailsQueryHandler : IRequestHandler<GetCommentDetailsQuery, CommentDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly ICommentRepository _commentRepository;

        public GetCommentDetailsQueryHandler(IMapper mapper, ICommentRepository commentRepository)
        {
            this._mapper = mapper;
            this._commentRepository = commentRepository;
        }

        public async Task<CommentDetailsDto> Handle(GetCommentDetailsQuery request, CancellationToken cancellationToken)
        {
            var comment = await _commentRepository.GetByIdAsync(request.Id) ?? throw new NotFoundException(nameof(Comment), request.Id);
            var data = _mapper.Map<CommentDetailsDto>(comment);
            return data;
        }
    }

}
