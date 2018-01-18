using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TurboCAR.GetTeams.Repository;
using TurboCAR.GetTeams.Model;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TurboCAR.GetTeams.Api.Controllers
{
    [Route("api/[controller]")]
    public class TeamController : Controller
    {
        private ITeamRepository repository;

        public TeamController(ITeamRepository _repository)
        {
            repository = _repository;
        }
        // GET: api/values
        [HttpGet]
        public async Task<List<Team>> Get()
        {
            return await repository.GetAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Team> Get(int id)
        {
            return await repository.GetAsync(id);
        }

       
    }
}
