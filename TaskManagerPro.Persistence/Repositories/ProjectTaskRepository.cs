using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Contracts.Persistence;
using TaskManagerPro.Domain.Common.Enums;
using TaskManagerPro.Domain.Entities;
using TaskManagerPro.Persistence.DatabaseContext;

namespace TaskManagerPro.Persistence.Repositories
{
    public class ProjectTaskRepository : GenericRepository<ProjectTask>, IProjectTaskRepository
    {
        public ProjectTaskRepository(TMPDatabaseContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<ProjectTask>> GetOpenTasksAsync()
        {
            return await _context.ProjectTasks
                .Where(t => t.Status == StatusOfTask.InProgress)
                .AsNoTracking()
                .ToListAsync();
        }


        public async Task<ProjectTask> GetTaskByIdWithCommentsAsync(int taskId)
        {
            var task =  await _context.ProjectTasks
                .Include(t => t.Comments)
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Id == taskId);
            if (task != null)
                return task;
            return new ProjectTask();
        }

        public async Task<IReadOnlyList<ProjectTask>> GetTasksByAssigneeAsync(int assigneeId)
        {
            return await _context.ProjectTasks
                .Where(t => t.AssigneeId == assigneeId)
                .AsNoTracking()
                .ToListAsync();
        }


        public async Task<IReadOnlyList<ProjectTask>> GetTasksByProjectAsync(int projectId)
        {
            return await _context.ProjectTasks
                .Where(t => t.ProjectId == projectId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<bool> IsTaskTitleUnique(string title)
        {
            return await _context.ProjectTasks.AnyAsync(q => q.Title == title) == false;
        }
    }
}
