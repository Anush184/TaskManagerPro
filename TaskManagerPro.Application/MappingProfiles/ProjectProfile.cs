using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Features.CustomProject.Commands.CreateProject;
using TaskManagerPro.Application.Features.CustomProject.Commands.UpdateProject;
using TaskManagerPro.Application.Features.CustomProject.Queries.GetAllProjects;
using TaskManagerPro.Application.Features.CustomProject.Queries.GetProjectDetails;
using TaskManagerPro.Domain.Entities;

namespace TaskManagerPro.Application.MappingProfiles;

public class ProjectProfile: Profile
{
    public ProjectProfile()
    {
        CreateMap< ProjectDto, Project > ().ReverseMap();
        CreateMap<Project, ProjectDetailsDto>().ReverseMap();
        CreateMap<CreateProjectCommand, Project>();
        CreateMap<UpdateProjectCommand, Project>();
    } 
}
