using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Contracts.Logging;
using TaskManagerPro.Application.Contracts.Persistence;
using TaskManagerPro.Application.Features.CustomProject.Queries.GetAllProjects;

namespace TaskManagerPro.Application.Features.CustomComment.Queries.GetAllComments
{
    public class GetCommentsQueryHandler : IRequestHandler<GetCommentsQuery, List<CommentDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICommentRepository _commentRepository;
        private readonly IAppLogger<GetCommentsQueryHandler> _logger;

        public GetCommentsQueryHandler(IMapper mapper, ICommentRepository commentRepository,
            IAppLogger<GetCommentsQueryHandler> logger)
        {
            this._mapper = mapper;
            this._commentRepository = commentRepository;
            this._logger = logger;
        }
        public async Task<List<CommentDto>> Handle(GetCommentsQuery request, CancellationToken cancellationToken)
        {
            var comments = await _commentRepository.GetAsync();
            var data = _mapper.Map<List<CommentDto>>(comments);
            _logger.LogInformation("Comments were retrieved successfully");
            return data;
        }
    }

}
