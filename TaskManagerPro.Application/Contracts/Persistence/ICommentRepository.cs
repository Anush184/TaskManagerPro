using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Domain.Entities;

namespace TaskManagerPro.Application.Contracts.Persistence;

public interface ICommentRepository: IGenericRepository<Comment>
{
    Task<IReadOnlyList<Comment>> GetCommentsByTaskIdAsync(int taskId);
    Task<IReadOnlyList<Comment>> GetCommentsByUserIdAsync(int userId);
}

