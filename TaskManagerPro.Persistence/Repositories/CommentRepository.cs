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
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(TMPDatabaseContext context) : base(context)
        {

        }
        public async Task<IReadOnlyList<Comment>> GetCommentsByTaskIdAsync(int taskId)
        {
            return await _context.Comments
                .Where(comment => comment.TaskId == taskId)
                .Include(q => q.Task)
                .AsNoTracking()
                .ToListAsync();
        }
        public async Task<IReadOnlyList<Comment>> GetCommentsByUserIdAsync(int userId)
        {
            return await _context.Comments
                .Include(q => q.User)
                .Where(comment => comment.UserId == userId)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
