using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Contracts.Persistence;
using TaskManagerPro.Application.Exceptions;
using TaskManagerPro.Domain.Entities;
using TaskManagerPro.Persistence.DatabaseContext;

namespace TaskManagerPro.Persistence.Repositories
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository(TMPDatabaseContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<Project>> GetProjectsByManagerAsync(int managerId)
        {
            return await _context.Projects
                .Where(p => p.ManagerId == managerId)
                .Include(q => q.Manager)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IReadOnlyList<Project>> GetOpenProjectsAsync()
        {
            return await _context.Projects
                .Where(p => !p.IsClosed)
                .AsNoTracking()
                .ToListAsync();
        }


        public async Task<Project> GetProjectDetails(int projectId)
        {
            var project = await _context.Projects
                    .Include(q => q.Manager)
                    .Include(q => q.Tasks)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(q => q.Id == projectId);
            return project;

        }
        public async Task<int> GetOpenProjectCountAsync()
        {
            return await _context.Projects
                .CountAsync(p => !p.IsClosed);
        }


        public async Task<IReadOnlyList<Project>> GetAllProjects()
        {
            var projects = await _context.Projects.ToListAsync();
            return projects;
        }

        public async Task<IReadOnlyList<ProjectTask>> GetProjectTasks(int projectId)
        {
            var project = await _context.Projects
                .FirstOrDefaultAsync(q => q.Id == projectId);
            if (project != null)
                return project.Tasks.ToList();
            return null;
        }

        public async Task<bool> IsProjectNameUnique(string name)
        {
            return await _context.Projects.AnyAsync(q => q.Name == name) == false;
        }
    }
}
