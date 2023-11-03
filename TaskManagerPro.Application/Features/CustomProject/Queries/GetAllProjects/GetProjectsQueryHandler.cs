using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Contracts.Logging;
using TaskManagerPro.Application.Contracts.Persistence;


namespace TaskManagerPro.Application.Features.CustomProject.Queries.GetAllProjects;

public class GetProjectsQueryHandler : IRequestHandler<GetProjectsQuery, List<ProjectDto>>
{
    private readonly IMapper _mapper;
    private readonly IProjectRepository _projectRepository;
    private readonly IAppLogger<GetProjectsQueryHandler> _logger;

    public GetProjectsQueryHandler(IMapper mapper, IProjectRepository projectRepository,
        IAppLogger<GetProjectsQueryHandler> logger)
    {
        this._mapper = mapper;
        this._projectRepository = projectRepository;
        this._logger = logger;
    }
    public async Task<List<ProjectDto>> Handle(GetProjectsQuery request, CancellationToken cancellationToken)
    {
        var projects = await _projectRepository.GetAsync();
        var data = _mapper.Map<List<ProjectDto>>(projects);
        _logger.LogInformation("Projects were retrieved successfully");
        return data;
    }
}
