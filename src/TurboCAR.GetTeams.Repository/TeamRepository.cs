using Newtonsoft.Json;
using Serilog;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TurboCAR.GetTeams.Model;

namespace TurboCAR.GetTeams.Repository
{
    public class TeamRepository : ITeamRepository
    {
        public TeamRepository()
        {
        }

        public async Task<List<Team>> GetAsync()
        {
            try
            {
                ConnectionMultiplexer Connection = ConnectionMultiplexer.Connect("localhost");
                IDatabase cache = Connection.GetDatabase();
                var returnRequests = JsonConvert.DeserializeObject<List<Team>>(cache.StringGet("TurboCAR.TeamsList"));
                return returnRequests;
            }
            catch (Exception ex)
            {
                Log.Error<Exception>("Error", ex);
                throw;
            }
        }

        public async Task<Team> GetAsync(int teamId)
        {
            var teams = await GetAsync();
            return teams.Find(x => x.Id == teamId);
        }
    }
}
