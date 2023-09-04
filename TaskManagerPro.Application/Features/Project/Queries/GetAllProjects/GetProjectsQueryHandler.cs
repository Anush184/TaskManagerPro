﻿using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Contracts.Persistence;
using TaskManagerPro.Application.Features.Task.Queries.GetAllTasks;

namespace TaskManagerPro.Application.Features.Project.Queries.GetAllProjects
{
    public class GetProjectsQueryHandler : IRequestHandler<GetProjectsQuery, List<ProjectDto>>
    {
        private readonly IMapper _mapper;
        private readonly IProjectRepository _projectRepository;

        public GetProjectsQueryHandler(IMapper mapper, IProjectRepository projectRepository)
        {
            this._mapper = mapper;
            this._projectRepository = projectRepository;
        }
        public async Task<List<ProjectDto>> Handle(GetProjectsQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var projects = await _projectRepository.GetAsync();
            //Convert data objects to DTO objects
            var data = _mapper.Map<List<ProjectDto>>(projects);
            //return list of DTO object
            return data;
        }
    }
}
