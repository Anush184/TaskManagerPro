using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Domain.Entities;

namespace TaskManagerPro.Application.Features.CustomTeam.Queries.GetTeamDetails
{
    public class TeamDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsClosed { get; set; }
        public ICollection<User> Members { get; set; }
        public ICollection<Project>? Projects { get; set; }
    }
}
