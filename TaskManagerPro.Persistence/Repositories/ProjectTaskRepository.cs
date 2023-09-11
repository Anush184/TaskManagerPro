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

        public async Task AddTasks(List<ProjectTask> projectTasks)
        {
            await _context.AddRangeAsync(projectTasks);
            await _context.SaveChangesAsync();  
        }

        public async Task<IReadOnlyList<ProjectTask>> GetTasksWithDetailsByProject(int projectId)
        {
            var tasks = await _context.ProjectTasks
                .Where(q => q.ProjectId == projectId)
                .Include(q => q.Project)
                .Include(q => q.Team)
                .Include(q => q.AssignedTo)
                .ToListAsync();
            return tasks;

        }
       public async Task<IReadOnlyList<ProjectTask>> GetTasksWithDetailsByTeam(int teamId)
        {
            var tasks = await _context.ProjectTasks
                .Where(q => q.TeamId == teamId)
                .Include (q => q.Team)   
                .Include(q => q.Project)
                .Include(q => q.AssignedTo)
                .ToListAsync();
            return tasks;
        }

        public async Task<IReadOnlyList<ProjectTask>> GetTasksWithDetailsByUser(int userId)
        {
            var tasks = await _context.ProjectTasks
                .Where(q => q.AssignedToId == userId)
                .Include(q => q.AssignedTo)
                .Include(q => q.Team)
                .Include(q => q.Project)
                .ToListAsync();
            return tasks;
        }

        public async Task<IReadOnlyList<ProjectTask>> GetTasksWithDetails()
        {
            var tasks =  await _context.ProjectTasks
                .Include(q => q.Project)
                .Include(q => q.Team)
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
        public async Task<IReadOnlyList<ProjectTask>> GetTasksByProjectAndTeamAndUser(int projectId, int teamId, int userId)
        {
            var tasks = await _context.ProjectTasks
                .Where(q => q.ProjectId == projectId && q.AssignedToId == userId && q.TeamId == teamId)
                .Include(q => q.Project)
                .Include(q => q.Team)
                .Include(q => q.AssignedTo)
                .ToListAsync();
            return tasks;
        }

        public async Task<IReadOnlyList<ProjectTask>> GetTasksByTeamMemberAndStatus(int userId, StatusOfTask status)
        {
            var tasks = await _context.ProjectTasks
                .Where(q => q.AssignedToId == userId && q.Status == status)
                .Include(q => q.Project)
                .Include(q => q.Team)
                .Include(q => q.AssignedTo)
                .ToListAsync();
            return tasks;

        }
        public async Task<IReadOnlyList<ProjectTask>> GetTasksByTeam(int teamId, StatusOfTask status)
        {
            var tasks = await _context.ProjectTasks
                .Where(q => q.TeamId == teamId && q.Status == status)
                .Include(q => q.Project)
                .Include(q => q.Team)
                .Include(q => q.AssignedTo)
                .ToListAsync();
            return tasks;

        }
        public async Task<bool> IsTaskTitleUnique(string title)
        {
            return await _context.ProjectTasks.AnyAsync(q => q.Title == title);
        }
    }
}
