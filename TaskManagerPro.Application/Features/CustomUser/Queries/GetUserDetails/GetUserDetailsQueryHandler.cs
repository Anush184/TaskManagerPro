using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Contracts.Persistence;
using TaskManagerPro.Application.Exceptions;
using TaskManagerPro.Application.Features.Task.Queries.GetTaskDetails;
using TaskManagerPro.Domain.Entities;

namespace TaskManagerPro.Application.Features.CustomUser.Queries.GetUserDetails
{
    public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, UserDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public GetUserDetailsQueryHandler(IMapper mapper, IUserRepository userRepository)
        {
            this._mapper = mapper;
            this._userRepository = userRepository;
        }

        public async Task<UserDetailsDto> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
        {
            var task = await _userRepository.GetByIdAsync(request.Id) ?? throw new NotFoundException(nameof(User), request.Id);
            var data = _mapper.Map<UserDetailsDto>(task);
            return data;
        }
    }

}
