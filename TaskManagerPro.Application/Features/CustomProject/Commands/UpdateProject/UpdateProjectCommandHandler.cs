using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Contracts.Persistence;
using TaskManagerPro.Application.Exceptions;
using TaskManagerPro.Application.Features.CustomProject.Commands.CreateProject;
using TaskManagerPro.Domain.Entities;

namespace TaskManagerPro.Application.Features.CustomProject.Commands.UpdateProject;

public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IProjectRepository _projectRepository;
    private readonly IUserRepository _userRepository;

    public UpdateProjectCommandHandler(IMapper mapper, 
        IProjectRepository projectRepository, IUserRepository userRepository)
    {
        this._mapper = mapper;
        this._projectRepository = projectRepository;
        this._userRepository = userRepository;
    }
    public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {

        var validator = new UpdateProjectCommandValidator(_projectRepository, _userRepository);
        var validatorResult = validator.Validate(request);
        if (validatorResult.Errors.Any())
            throw new BadRequestException("Invalid Project", validatorResult);

        var project = await _projectRepository.GetByIdAsync(request.Id);
        if (project is null)
            throw new NotFoundException(nameof(Project), request.Id);

        _mapper.Map(request, project);
       
        await _projectRepository.UpdateAsync(project);
        return Unit.Value;
    }
}
