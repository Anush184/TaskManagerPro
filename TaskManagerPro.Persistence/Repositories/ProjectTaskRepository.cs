using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Contracts.Persistence;
using TaskManagerPro.Domain.Entities;
using TaskManagerPro.Persistence.DatabaseContext;

namespace TaskManagerPro.Persistence.Repositories
{
    public class ProjectTaskRepository : GenericRepository<ProjectTask>, IProjectTaskRepository
    {
        public ProjectTaskRepository(TMPDatabaseContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<ProjectTask>> GetTasksWithDetailsByProject(int projectId)
        {
            var tasks = await _context.ProjectTasks
                .Where(q => q.ProjectId == projectId)
                .Include(q => q.Project)
                .Include(q => q.AssignedTo)
                .ToListAsync();
            return tasks;

        }

        public async Task<IReadOnlyList<ProjectTask>> GetTasksWithDetailsByUser(int userId)
        {
            var tasks = await _context.ProjectTasks
                .Where(q => q.AssignedToId == userId)
                .Include(q => q.Project)
                .Include(q => q.AssignedTo)
                .ToListAsync();
            return tasks;
        }

        public async Task<IReadOnlyList<ProjectTask>> GetTasksWithDetails()
        {
            var tasks =  await _context.ProjectTasks
                .Include(q => q.Project)
                .Include(q => q.AssignedTo)
                .ToListAsync();
            return tasks;
        }

        public async Task<ProjectTask> GetTaskWithDetails(int id)
        {
            var task = await _context.ProjectTasks
                .Include (q => q.Project)
                .Include(q => q.AssignedTo)
                .FirstOrDefaultAsync(q => q.Id == id);
            return task;

        }
        public async Task<IReadOnlyList<ProjectTask>> GetTasksByProjectAndUser(int projectId, int userId)
        {
            var tasks = await _context.ProjectTasks
                .Include(q => q.Project)
                .Include(q => q.AssignedTo)
                .Where(q => q.ProjectId == projectId && q.AssignedToId == userId)
                .ToListAsync();
            return tasks;
        }

        public async Task<IReadOnlyList<ProjectTask>> GetTasksByTeamMemberAndStatus(int userId, string status)
        {
            var tasks = await _context.ProjectTasks
                 .Include(q => q.Project)
                 .Include(q => q.AssignedTo)
                 .Where(q => q.AssignedToId == userId && q.Status == status)
                 .ToListAsync();
            return tasks;

        }
        public async Task<bool> IsTaskTitleUnique(string title)
        {
            return await _context.ProjectTasks.AnyAsync(q => q.Title == title);
        }
    }
}
