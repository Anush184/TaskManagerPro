using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Contracts.Persistence;
using TaskManagerPro.Application.Exceptions;
using TaskManagerPro.Application.Features.CustomTeam.Commands.CreateTeam;
using TaskManagerPro.Domain.Entities;

namespace TaskManagerPro.Application.Features.CustomTeam.Commands.CreateTeam;

public class CreateTeamCommandHandler : IRequestHandler<CreateTeamCommand, int>
{
    private readonly IMapper _mapper;
    private readonly ITeamRepository _teamRepository;
    private readonly IUserRepository _userRepository;

    public CreateTeamCommandHandler(IMapper mapper, ITeamRepository teamRepository, IUserRepository userRepository)
    {
        _mapper = mapper;
        _teamRepository = teamRepository;
        _userRepository = userRepository;
    }

    public async Task<int> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateTeamCommandValidator(_teamRepository);
        var validatorResult = await validator.ValidateAsync(request);
        if (validatorResult.Errors.Any())
            throw new BadRequestException("Invalid Team", validatorResult);

        var teamToCreate = _mapper.Map<Team>(request);
        var members = await _userRepository.GetUsersByIdsAsync(request.MemberIds);
        if (members == null || members.Count != request.MemberIds.Count)
        {
            throw new BadRequestException("Invalid Team Member Ids");
        }

        foreach (var member in members)
        {
            teamToCreate.Members.Add(member);
        }

        await _teamRepository.CreateAsync(teamToCreate);

        return teamToCreate.Id; 
    }

}
