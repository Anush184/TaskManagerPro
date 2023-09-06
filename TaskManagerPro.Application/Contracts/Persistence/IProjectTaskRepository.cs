using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManagerPro.Domain.Entities;

namespace TaskManagerPro.Application.Contracts.Persistence
{
    public interface IProjectTaskRepository : IGenericRepository<ProjectTask>
    {
        Task<ProjectTask> GetTaskWithDetails(int id);
        Task<IReadOnlyList<ProjectTask>> GetTasksWithDetailsByProject(int projectid);
        Task<IReadOnlyList<ProjectTask>> GetTasksWithDetailsByUser(int userId);
        Task<IReadOnlyList<ProjectTask>> GetTasksWithDetails();
        Task<IReadOnlyList<ProjectTask>> GetTasksByProjectAndUser(int projectId, int userId);
        Task<IReadOnlyList<ProjectTask>> GetTasksByTeamMemberAndStatus(int userId, string status);
        Task<bool> IsTaskTitleUnique(string description);
    }
}
