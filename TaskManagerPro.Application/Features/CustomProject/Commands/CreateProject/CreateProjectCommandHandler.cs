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

namespace TaskManagerPro.Application.Features.CustomProject.Commands.CreateProject;

public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand,int>
{
    private readonly IMapper _mapper;
    private readonly IProjectRepository _projectRepository;
    private readonly IUserRepository _userRepository;

    public CreateProjectCommandHandler(IMapper mapper, 
        IProjectRepository projectRepository, IUserRepository userRepository)
    {
        this._mapper = mapper;
        this._projectRepository = projectRepository;
        this._userRepository = userRepository;
    }
    public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateProjectCommandValidator(_projectRepository, _userRepository);
        var validatorResult = validator.Validate(request);

        if (validatorResult.Errors.Any())
           throw new BadRequestException("Invalid Project", validatorResult);

        var projectToCreate = _mapper.Map<Project>(request);

        await _projectRepository.CreateAsync(projectToCreate);
        return projectToCreate.Id;


    }
}
