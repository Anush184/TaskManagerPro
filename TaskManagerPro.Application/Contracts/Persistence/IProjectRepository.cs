using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Domain.Entities;

namespace TaskManagerPro.Application.Contracts.Persistence
{
    public interface IProjectRepository: IGenericRepository<Project>
    {
        Task<Project> GetProjectWithDetails(int id);
        Task<IReadOnlyList<Project>> GetProjectsByManager(int managerId);
        Task<Project> GetOpenProjectsByTeamMember(int userId);
        Task<IReadOnlyList<Project>> GetProjectsWithDetails();
        Task<bool> ProjectExist(int managerId, string name);
        Task<bool> IsProjectNameUnique(string description);
        Task<IReadOnlyList<Project>> GetRecentProjects(int count);
        Task<IReadOnlyList<Project>> GetClosedProjectsByTeamMember(int userId);
    }
}
