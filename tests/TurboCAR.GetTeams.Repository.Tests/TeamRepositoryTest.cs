using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TurboCAR.GetTeams.Model;
using Xunit;

namespace TurboCAR.GetTeams.Repository.Tests
{
    public class TeamRepositoryTest
    {
        private TeamRepository repository = null;
        private Team expectedTeam = null;
        private int expectedCount = 21;
        public TeamRepositoryTest()
        {
            repository = new TeamRepository();
            expectedTeam = new Team() { Id = 101, Name = "11A", Department = "CP98PCL" };
        }

        [Fact]
        public async Task GetAsyncTest()
        {
            var result = repository.GetAsync();
            int actual = result.Result.Count;
            Assert.True(actual == expectedCount);
        }

        [Fact]
        public async Task GetAsyncWithParameterTest()
        {
            var actual = repository.GetAsync(101).Result;
            Assert.True(actual.Id == expectedTeam.Id && actual.Name == expectedTeam.Name && actual.Department == expectedTeam.Department);
        }
    }
}
