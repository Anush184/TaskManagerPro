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
        Task AddProjects(List<ProjectTask> projects);
        Task<IReadOnlyList<Project>> GetProjectsWithDetails();
        Task<Project> GetProjectWithDetails(int id);
        Task<IReadOnlyList<Project>> GetProjectsByManager(int managerId);
        Task<IReadOnlyList<Project>> GetOpenProjectsByTeam(int teamId);
        Task<IReadOnlyList<Project>> GetClosedProjectsByTeam(int teamId);
        Task<bool> ProjectExist(int managerId, string name);
        Task<bool> IsProjectNameUnique(string name);
        Task<IReadOnlyList<Project>> GetRecentProjects(int count);
        
    }
}
