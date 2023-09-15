using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Contracts.Persistence;


namespace TaskManagerPro.Application.Features.CustomTeam.Queries.GetAllQueries
{
    public class GetTeamsQueryHandler : IRequestHandler<GetTeamsQuery, List<TeamDto>>
    {
        private readonly IMapper _mapper;
        private readonly ITeamRepository _teamRepository;

        public GetTeamsQueryHandler(IMapper mapper, ITeamRepository teamRepository)
        {
            this._mapper = mapper;
            this._teamRepository = teamRepository;
        }
        public async Task<List<TeamDto>> Handle(GetTeamsQuery request, CancellationToken cancellationToken)
        {
            var teams = await _teamRepository.GetAsync();
            var data = _mapper.Map<List<TeamDto>>(teams);
            return data;
        }
    }
}
