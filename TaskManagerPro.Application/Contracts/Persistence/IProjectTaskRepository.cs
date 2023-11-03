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
        Task<IReadOnlyList<ProjectTask>> GetTasksByProjectAsync(int projectId);
        Task<IReadOnlyList<ProjectTask>> GetTasksByAssigneeAsync(int assigneeId);
        Task<IReadOnlyList<ProjectTask>> GetOpenTasksAsync();
        Task<ProjectTask> GetTaskByIdWithCommentsAsync(int taskId);
        Task<bool> IsTaskTitleUnique(string name);
    }
}
