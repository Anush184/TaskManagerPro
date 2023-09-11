using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Features.Layout.Queries.GetAllProjects;
using TaskManagerPro.Application.Features.Layout.Queries.GetProjectDetails;
using TaskManagerPro.Domain.Entities;

namespace TaskManagerPro.Application.MappingProfiles;

public class ProjectProfile: Profile
{
    public ProjectProfile()
    {
        CreateMap< ProjectDto, Project > ().ReverseMap();
        CreateMap<Project, ProjectDetailsDto>().ReverseMap();
    } 
}
