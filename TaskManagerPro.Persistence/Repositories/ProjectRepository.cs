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

        public async Task AddProjects(List<ProjectTask> projects)
        {
            await _context.AddRangeAsync(projects);
            await _context.SaveChangesAsync();
        }


        public async Task<IReadOnlyList<Project>> GetClosedProjectsByTeam(int teamId)
        {
            return await _context.Projects
                .Where(q => q.IsClosed == true && q.TeamId == teamId)
                .Include(q => q.Team)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<Project>> GetOpenProjectsByTeam(int teamId)
        {
            return await _context.Projects
                .Where(q => q.IsClosed == false && q.TeamId == teamId)
                .Include(q => q.Team)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<Project>> GetProjectsByManager(int managerId)
        {
            return await _context.Projects
                .Where(q => q.ManagerId == managerId)
                .Include(q => q.Manager)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<Project>> GetProjectsWithDetails()
        {
            return await _context.Projects
                .Include(q => q.Manager)
                .Include(q => q.Team)
                .Include(q => q.Tasks)
                .ToListAsync();
        }

        public async Task<Project> GetProjectWithDetails(int id)
        {
            var project = await _context.Projects
                    .Include(q => q.Manager)
                    .Include(q => q.Team)
                    .Include(q => q.Tasks)
                    .FirstOrDefaultAsync(q => q.Id == id);
            return project;

        }

        public async Task<IReadOnlyList<Project>> GetRecentProjects(int count)
        {
            var recentProjects = await _context.Projects
                    .Where(q => !q.IsClosed)
                    .OrderByDescending(q => q.CreatedAt)
                    .Take(count)
                    .ToListAsync();

                return recentProjects;
        }
               
        public async Task<bool> IsProjectNameUnique(string name)
        {
            return await _context.Projects.AnyAsync(q => q.Name == name);
        }

        public async Task<bool> ProjectExist(int managerId, string name)
        {
            return await _context.Projects
                .AnyAsync(q => q.ManagerId == managerId && q.Name == name);
        }
    }
}
