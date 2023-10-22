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
        Task<IReadOnlyList<Project>> GetAllProjects();
        Task<IReadOnlyList<Project>> GetProjectsByManagerAsync(int managerId);
        Task<IReadOnlyList<Project>> GetOpenProjectsAsync();
        Task<int> GetOpenProjectCountAsync();
        Task<IReadOnlyList<ProjectTask>> GetProjectTasks(int projectId);

    }
}
