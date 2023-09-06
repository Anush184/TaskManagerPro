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
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository(TMPDatabaseContext context) : base(context)
        {
        }

        public Task<IReadOnlyList<Project>> GetClosedProjectsByTeamMember(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<Project> GetOpenProjectsByTeamMember(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Project>> GetProjectsByManager(int managerId)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Project>> GetProjectsWithDetails()
        {
            throw new NotImplementedException();
        }

        public Task<Project> GetProjectWithDetails(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Project>> GetRecentProjects(int count)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsProjectDescriptionUnique(string description)
        {
            return await _context.Projects.AnyAsync(q => q.Description == description);
        }

        public Task<bool> IsProjectNameUnique(string description)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ProjectExist(int managerId, string name)
        {
            throw new NotImplementedException();
        }
    }
}
