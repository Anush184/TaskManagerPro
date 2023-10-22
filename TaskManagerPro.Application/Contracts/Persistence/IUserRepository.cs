using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Domain.Common.Enums;
using TaskManagerPro.Domain.Entities;

namespace TaskManagerPro.Application.Contracts.Persistence;


public interface IUserRepository : IGenericRepository<User>
{
    Task<User> GetUserByEmailAsync(string email);
    Task<IReadOnlyList<User>> GetUsersByRoleAsync(Role roleName);
    Task<IReadOnlyList<User>> GetUserByTask(int taskId);
    Task<User> GetUserByPhone(string phone);
}

