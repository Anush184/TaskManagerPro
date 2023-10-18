using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Contracts.Logging;
using TaskManagerPro.Application.Contracts.Persistence;
using TaskManagerPro.Domain.Entities;
using TaskManagerPro.Persistence.DatabaseContext;

namespace TaskManagerPro.Persistence.Repositories
{
    public class TeamRepository : GenericRepository<Team>, ITeamRepository
    {
        private readonly IAppLogger<Team> _logger;


        public TeamRepository(TMPDatabaseContext context, IAppLogger<Team> logger) : base(context)
        {
            this._logger = logger;
        }

        public  async Task<User> GetTeamMember(int teamId, int memberId)
        {
            var team = await _context.Teams
               .FirstOrDefaultAsync(q => q.Id == teamId);
            if (team == null)
            {
                _logger.LogWorning("Invalid Team Id.");
            }
            var teamMember = team.Members.FirstOrDefault(q => q.Id == memberId);
            if (teamMember == null)
            {
                _logger.LogWorning("Invalid Member Id.");
            }

            return teamMember;
        }

        public async Task<IReadOnlyList<User>> GetTeamMembers(int teamId)
        {
            var team = await _context.Teams
                .FirstOrDefaultAsync(q => q.Id == teamId);
            if (team == null)
            {
                _logger.LogWorning("Invalid Team Id.");
            }
            return team.Members.ToList();
        }

        public Task<IReadOnlyList<Project>> GetTeamProjects(int teamId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsTeamNameUnique(string name)
        {
            throw new NotImplementedException();
        }
    }
}
