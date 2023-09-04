using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Domain;

namespace TaskManagerPro.Application.Features.Project.Commands.UpdateProject
{
    public class UpdateProjectCommand: IRequest<Unit>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? EndDate { get; set; }
        public string ManagerId { get; set; }  // ID of the project manager (foreign key to User)
        public User Manager { get; set; }  // Navigation property to the project manager
        public ICollection<Domain.Task>? Tasks { get; set; }  // Collection of tasks associated with the project

    }
}
