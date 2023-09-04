using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Domain;

namespace TaskManagerPro.Application.Features.Project.Queries.GetProjectDetails
{
    public class ProjectDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }  // Date and time the entity was created
        public DateTime? UpdatedAt { get; set; }  // Date and time the entity was last updated (nullable)
        public bool IsDeleted { get; set; }  // Flag indicating if the entity is deleted
        public DateTime? EndDate { get; set; }
        public string ManagerId { get; set; }  // ID of the project manager (foreign key to User)
     

    }
}
