using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Domain;

namespace TaskManagerPro.Application.Contracts.Persistence
{
    public interface IUserRepository: IGenericRepository<User>
    {
    }
}
