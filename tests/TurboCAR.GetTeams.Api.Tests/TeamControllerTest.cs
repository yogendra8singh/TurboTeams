using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TurboCAR.GetTeams.Model;
using TurboCAR.GetTeams.Repository;
using NSubstitute;
using Xunit;
using TurboCAR.GetTeams.Api.Controllers;
using Newtonsoft.Json;

namespace TurboCAR.GetTeams.Api.Tests
{
    public class TeamControllerTest
    {
        private TeamController controller = null;
        private ITeamRepository repository = null;
        private Team expectedTeam = null;
        private int expectedCount = 21;
        private List<Team> teams = null;
        public TeamControllerTest()
        {
            repository = Substitute.For<ITeamRepository>();
            controller = new TeamController(repository);
            expectedTeam = new Team() { Id = 101, Name = "11A", Department = "CP98PCL" };
            teams = JsonConvert.DeserializeObject<List<Team>>("[{\"id\":101,\"name\":\"11A\",\"department\":\"CP98PCL\"},{\"id\":102,\"name\":\"11B\",\"department\":\"CP30ACT\"}]");
        }

        [Fact]
        public async Task GetAsyncTest()
        {
            repository.GetAsync().Returns(Task.Run(() => teams));
            var result = controller.Get();
            int actual = result.Result.Count;
            Assert.True(actual == teams.Count);
        }

        [Fact]
        public async Task GetAsyncWithParameterTest()
        {
            repository.GetAsync(Arg.Any<int>()).Returns(Task.Run(() => expectedTeam));
            var actual = repository.GetAsync(101).Result;
            Assert.True(actual.Id == expectedTeam.Id && actual.Name == expectedTeam.Name && actual.Department == expectedTeam.Department);
        }
    }
}
