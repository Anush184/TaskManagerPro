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
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(TMPDatabaseContext context) : base(context)
        {
        }

        public Task<List<User>> GetUsersByIdsAsync(ICollection<int> memberIds)
        {
            throw new NotImplementedException();
        }
    }
}
