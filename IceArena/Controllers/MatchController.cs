using IceArena.Data.Models;
using IceArena.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IceArena.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MatchController : Controller
    {
        private readonly IMatchService _matchService;

        public MatchController(IMatchService matchService)
        {
            _matchService = matchService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMatch(int id)
        {
            var match = await _matchService.GetMatchAsync(id);
            return match != null ? Ok(match) : NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMatches()
        {
            var matches = await _matchService.GetAllMatchesAsync();
            return Ok(matches);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMatch([FromBody] Match match)
        {
            await _matchService.CreateMatchAsync(match);
            return CreatedAtAction(nameof(GetMatch),new {id = match.Id}, match);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMatch(int id, [FromBody] Match match)
        {
            if (id != match.Id) return BadRequest("Id mismatch");
            await _matchService.UpdateMatchAsync(match); 
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMatch(int id)
        {
            await _matchService.DeleteMatchAsync(id);
            return NoContent();
        }
    }
}
