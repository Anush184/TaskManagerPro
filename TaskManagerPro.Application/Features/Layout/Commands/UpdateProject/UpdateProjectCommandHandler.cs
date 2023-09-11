using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Contracts.Persistence;

namespace TaskManagerPro.Application.Features.Layout.Commands.UpdateProject;

internal class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IProjectRepository _projectRepository;

    public UpdateProjectCommandHandler(IMapper mapper, IProjectRepository projectRepository)
    {
        this._mapper = mapper;
        this._projectRepository = projectRepository;
    }
    public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
       var projectToUpdate = _mapper.Map<Domain.Entities.Project>(request);
        await _projectRepository.UpdateAsync(projectToUpdate);
        return Unit.Value;
    }
}
