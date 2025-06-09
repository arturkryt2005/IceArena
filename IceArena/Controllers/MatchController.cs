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
            if (match.Team1Id == match.Team2Id)
            {
                return BadRequest("Команда 1 и команда 2 не могут быть одинаковыми.");
            }

            if (match.MatchDate < DateTime.UtcNow)
            {
                return BadRequest("Дата матча не может быть в прошлом.");
            }

            if (string.IsNullOrWhiteSpace(match.Location))
            {
                return BadRequest("Место проведения обязательно.");
            }

            if (match.Location.Length > 100)
            {
                return BadRequest("Место проведения не может быть длиннее 100 символов.");
            }

            if (string.IsNullOrWhiteSpace(match.Result))
            {
                return BadRequest("Результат обязателен.");
            }

            if (match.Result.Length > 50)
            {
                return BadRequest("Результат не может быть длиннее 50 символов.");
            }

            await _matchService.CreateMatchAsync(match);
            return CreatedAtAction(nameof(GetMatch), new { id = match.Id }, match);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMatch(int id, [FromBody] Match match)
        {
            if (id != match.Id)
            {
                return BadRequest("ID в маршруте и теле запроса не совпадают.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (match.Team1Id == match.Team2Id)
            {
                return BadRequest("Команда 1 и команда 2 не могут быть одинаковыми.");
            }

            if (string.IsNullOrWhiteSpace(match.Location))
            {
                return BadRequest("Место проведения обязательно.");
            }

            if (match.Location.Length > 100)
            {
                return BadRequest("Место проведения не может быть длиннее 100 символов.");
            }

            if (string.IsNullOrWhiteSpace(match.Result))
            {
                return BadRequest("Результат обязателен.");
            }

            if (match.Result.Length > 50)
            {
                return BadRequest("Результат не может быть длиннее 50 символов.");
            }

            try
            {
                await _matchService.UpdateMatchAsync(match);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ошибка при обновлении матча: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatch(int id)
        {
            await _matchService.DeleteMatchAsync(id);
            return NoContent();
        }
    }
}