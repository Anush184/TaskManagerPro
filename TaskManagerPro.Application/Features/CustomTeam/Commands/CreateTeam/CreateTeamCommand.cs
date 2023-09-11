using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Domain.Entities;

namespace TaskManagerPro.Application.Features.CustomTeam.Commands.CreateTeam;

public class CreateTeamCommand : IRequest<int>
{
    public string Name { get; set; }
    public List<int> MemberIds { get; set; }
}
