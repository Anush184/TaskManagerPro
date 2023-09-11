using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Domain.Entities;

namespace TaskManagerPro.Application.Contracts.Persistence;

public interface ITeamRepository:IGenericRepository<Team>
{
    Task<IReadOnlyList<User>> GetTeamMembers(int teamId);
    Task<IReadOnlyList<Project>> GetTeamProjects(int teamId);
    Task<User> GetTeamMember(int teamId, int memberId);
    Task<bool> IsTeamNameUnique(string name);
}
