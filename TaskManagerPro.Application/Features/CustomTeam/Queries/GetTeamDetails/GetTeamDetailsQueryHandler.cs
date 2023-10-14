using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Contracts.Persistence;
using TaskManagerPro.Application.Exceptions;
using TaskManagerPro.Domain.Entities;

namespace TaskManagerPro.Application.Features.CustomTeam.Queries.GetTeamDetails
{
    public class GetTeamDetailsQueryHandler : IRequestHandler<GetTeamDetailsQuery, TeamDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly ITeamRepository _teamRepository;

        public GetTeamDetailsQueryHandler(IMapper mapper, ITeamRepository teamRepository)
        {
            this._mapper = mapper;
            this._teamRepository = teamRepository;
        }

        public async Task<TeamDetailsDto> Handle(GetTeamDetailsQuery request, CancellationToken cancellationToken)
        {
            var team = await _teamRepository.GetByIdAsync(request.Id) ?? throw new NotFoundException(nameof(Team), request.Id);
            var data = _mapper.Map<TeamDetailsDto>(team);
            return data;
        }
    }
}
