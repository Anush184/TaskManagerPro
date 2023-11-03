using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Features.Task.Commands.CreateTask;
using TaskManagerPro.Application.Features.Task.Commands.UpdateTask;
using TaskManagerPro.Application.Features.Task.Queries.GetAllTasks;
using TaskManagerPro.Application.Features.Task.Queries.GetTaskDetails;
using TaskManagerPro.Domain.Common.Enums;
using TaskManagerPro.Domain.Entities;

namespace TaskManagerPro.Application.MappingProfiles;

public class TaskProfile : Profile
{
    public TaskProfile()
    {
        CreateMap<TaskDto, ProjectTask>().ReverseMap();
        CreateMap<ProjectTask, TaskDetailsDto>();
        CreateMap<CreateTaskCommand, ProjectTask>()
           .ForMember(dest => dest.Status, opt => opt.MapFrom(src => StatusOfTask.NotStarted));
        CreateMap<UpdateTaskCommand, ProjectTask>().ReverseMap();
        

    }
}
