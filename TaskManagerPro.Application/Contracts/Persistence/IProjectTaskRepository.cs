using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManagerPro.Domain.Common.Enums;
using TaskManagerPro.Domain.Entities;

namespace TaskManagerPro.Application.Contracts.Persistence
{
    public interface IProjectTaskRepository : IGenericRepository<ProjectTask>
    {
        Task<ProjectTask> GetTaskWithDetails(int id);
        Task<IReadOnlyList<ProjectTask>> GetTasksWithDetailsByProject(int projectid);
        Task<IReadOnlyList<ProjectTask>> GetTasksWithDetailsByTeam(int teamId);
        Task<IReadOnlyList<ProjectTask>> GetTasksWithDetailsByUser(int userId);
        Task<IReadOnlyList<ProjectTask>> GetTasksWithDetails();
        Task<IReadOnlyList<ProjectTask>> GetTasksByProjectAndTeamAndUser(int projectId, int teamId, int userId);
        Task<IReadOnlyList<ProjectTask>> GetTasksByTeam(int teamId, StatusOfTask status);
        Task<IReadOnlyList<ProjectTask>> GetTasksByTeamMemberAndStatus(int userId, StatusOfTask status);
        Task<bool> IsTaskTitleUnique(string description);
        Task AddTasks(List<ProjectTask> projectTasks);
    }
}
