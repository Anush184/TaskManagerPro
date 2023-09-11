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

namespace TaskManagerPro.Application.Features.Layout.Queries.GetProjectDetails;

public class GetProjectDetailsQueryHandler : IRequestHandler<GetProjectDetailsQuery, ProjectDetailsDto>
{
    private readonly IMapper _mapper;
    private readonly IProjectRepository _projectRepository;

    public GetProjectDetailsQueryHandler(IMapper mapper, IProjectRepository projectRepository)
    {
        this._mapper = mapper;
        this._projectRepository = projectRepository;
    }

    public async Task<ProjectDetailsDto> Handle(GetProjectDetailsQuery request, CancellationToken cancellationToken)
    {
        var project = await _projectRepository.GetByIdAsync(request.Id) ?? throw new NotFoundException(nameof(Project), request.Id);
        var data = _mapper.Map<ProjectDetailsDto>(project);
        return data;
    }
}
