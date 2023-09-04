using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Contracts.Persistence;
using TaskManagerPro.Persistence.DatabaseContext;

namespace TaskManagerPro.Persistence.Repositories
{
    public class TaskRepository : GenericRepository<Domain.Task>, ITaskRepository
    {
        public TaskRepository(TMPDatabaseContext context) : base(context)
        {
        }

        public async Task<bool> IsTaskDescriptionUnique(string description)
        {
            return await _context.Tasks.AnyAsync(q => q.Description == description);
        }
    }
}
