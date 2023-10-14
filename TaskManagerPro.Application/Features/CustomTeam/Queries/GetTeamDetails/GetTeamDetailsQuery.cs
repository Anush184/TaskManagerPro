using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerPro.Application.Features.CustomTeam.Queries.GetTeamDetails;

public record GetTeamDetailsQuery(int Id) : IRequest<TeamDetailsDto>;

