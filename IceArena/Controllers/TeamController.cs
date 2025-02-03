using IceArena.Data.Models;
using IceArena.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IceArena.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController : Controller
    {
        private readonly ITeamService _teamservice;

        public TeamController(ITeamService teamservice)
        {
            _teamservice = teamservice;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetTeam(int id)
        {
            var team = await _teamservice.GetTeamAsync(id);
            return team != null ? Ok(team) : NotFound();
        }

        [HttpGet]
        public async Task<ActionResult> GetAllTeams() 
        {
            var teams = await _teamservice.GetAllTeamsByAsync();
            return Ok(teams);
        }

        [HttpPost]
        public async Task<ActionResult> CreateTeam([FromBody] Team team)
        {
            await _teamservice.CreateTeamByAsync(team);
            return CreatedAtAction(nameof(GetTeam),new {id = team.Id}, team);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTeam(int id, [FromBody] Team team)
        {
            if (id != team.Id) return BadRequest("ID mismatch");
            await _teamservice.UpdateTeamByAsync(team);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTeam(int id)
        {
            await _teamservice.DeleteTeamByAsync(id);
            return NoContent();
        }
    }
}
