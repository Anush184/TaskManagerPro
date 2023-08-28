using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task = TaskManagerPro.Domain.Task;

namespace TaskManagerPro.Application.Contracts.Persistence
{
    public interface ITaskRepository : IGenericRepository<Task>
    {
        Task<bool> IsTaskDescriptionUnique(string description);
    }
}
