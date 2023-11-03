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
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(TMPDatabaseContext context) : base(context)
        {
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            var user =  await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email);
            if (user != null)
                return user;
            return new User();
        }

        public async Task<IReadOnlyList<User>> GetUsersByRoleAsync(Role roleName)
        {
            return await _context.Users
                .Where(u => u.RoleName == roleName)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IReadOnlyList<User>> GetUserByTask(int taskId)
        {
            return await _context.Users
                .Where(user => user.Tasks.Any(task => task.Id == taskId))
                .AsNoTracking()
                .ToListAsync();
        }
        public async Task<User> GetUserByPhone(string phone)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(user => user.Phone == phone);
            if (user != null)
                return user;
            return new User();
                
               

        }
        public async Task<bool> IsUserNameUnique(string username)
        {
            return await _context.Users.AnyAsync(u => u.UserName == username) == false;
        }
    }
}
