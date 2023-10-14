using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerPro.Application.Features.CustomProject.Queries.GetAllProjects;

public class ProjectDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ManagerId { get; set; }
    public DateTime? CreatedAt { get; set; }
    public bool IsClosed { get; set; }
}
