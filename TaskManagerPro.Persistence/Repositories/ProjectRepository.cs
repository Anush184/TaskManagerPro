using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Contracts.Persistence;
using TaskManagerPro.Domain;
using TaskManagerPro.Persistence.DatabaseContext;

namespace TaskManagerPro.Persistence.Repositories
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository(TMPDatabaseContext context) : base(context)
        {
        }
        public async Task<bool> IsProjectDescriptionUnique(string description)
        {
            return await _context.Projects.AnyAsync(q => q.Description == description);
        }
    }
}
