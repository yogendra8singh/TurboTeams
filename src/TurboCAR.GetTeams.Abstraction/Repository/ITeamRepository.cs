using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TurboCAR.GetTeams.Model;

namespace TurboCAR.GetTeams.Repository
{
    public interface ITeamRepository
    {
        Task<List<Team>> GetAsync();

        Task<Team> GetAsync(int teamId);
    }
}
