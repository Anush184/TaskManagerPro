using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Features.CustomTeam.Queries.GetAllQueries;
using TaskManagerPro.Application.Features.CustomTeam.Queries.GetTeamDetails;
using TaskManagerPro.Domain.Entities;

namespace TaskManagerPro.Application.MappingProfiles
{
    public class TeamProfile : Profile
    {
        public TeamProfile()
        {
            CreateMap<TeamDto, Team>().ReverseMap();
            CreateMap<Team, TeamDetailsDto>().ReverseMap();
        }
    }
}
