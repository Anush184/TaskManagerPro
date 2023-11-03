using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Features.Task.Queries.GetTaskDetails;
using TaskManagerPro.Application.Features.CustomUser.Queries.GetAllUsers;
using TaskManagerPro.Domain;

namespace TaskManagerPro.Application.Features.CustomProject.Queries.GetProjectDetails;

public class ProjectDetailsDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public UserDto Manager { get; set; }
    public List<TaskDetailsDto> Tasks { get; set; }

}
