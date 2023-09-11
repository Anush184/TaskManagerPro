using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Features.Task.Queries.GetAllTasks;
using TaskManagerPro.Application.Features.Task.Queries.GetTaskDetails;
using TaskManagerPro.Domain.Entities;

namespace TaskManagerPro.Application.MappingProfiles;

public class TaskProfile : Profile
{
    public TaskProfile()
    {
        CreateMap<TaskDto, ProjectTask>().ReverseMap();
        CreateMap<ProjectTask, TaskDetailsDto>().ReverseMap();
    }
}
