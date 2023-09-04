using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Features.Project.Queries.GetAllProjects;
using TaskManagerPro.Application.Features.Project.Queries.GetProjectDetails;
using TaskManagerPro.Application.Features.Task.Queries.GetAllTasks;
using TaskManagerPro.Application.Features.Task.Queries.GetTaskDetails;

namespace TaskManagerPro.Application.MappingProfiles
{
    public class ProjectProfile: Profile
    {
        public ProjectProfile()
        {
            CreateMap< ProjectDto, Domain.Project > ().ReverseMap();
            CreateMap<Domain.Project, ProjectDetailsDto>().ReverseMap();
        } 
    }
}
