using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Features.Task.Queries.GetAllTasks;
using TaskManagerPro.Application.Features.CustomUser.Queries.GetAllUsers;

namespace TaskManagerPro.Application.Features.CustomProject.Queries.GetAllProjects;

public class ProjectDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public UserDto Manager { get; set; }
    public List<TaskDto> Tasks { get; set; }
}
