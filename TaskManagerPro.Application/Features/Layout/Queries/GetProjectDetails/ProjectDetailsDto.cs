using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Domain;

namespace TaskManagerPro.Application.Features.Layout.Queries.GetProjectDetails;

public class ProjectDetailsDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } 
    public DateTime? UpdatedAt { get; set; } 
    public string ManagerId { get; set; }
    public int TeamId { get; set; }
    public bool IsClosed { get; set; }

}
