using IceArena.Data.Models;
using IceArena.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IceArena.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : Controller
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService) 
        {
            _playerService = playerService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlayer(int id)
        {
            var player = await _playerService.GetPlayerByAsync(id);
            return player != null ? Ok(player) : NotFound();
        }

        [HttpGet]
        public async Task<ActionResult> GetAllPlayers()
        {
            var players = await _playerService.GetAllPlayersByAsync();
            return Ok(players);
        }

        [HttpPost]
        public async Task<ActionResult> CreatePlayer([FromBody] Player player)
        {
            await _playerService.CreatePlayerByAsync(player);
            return CreatedAtAction(nameof(GetPlayer), new { id = player.Id }, player);
        }

        [HttpPut]
        public async Task<ActionResult> UpdatePlayer(int id, [FromBody] Player player)
        {
            if (id != player.Id) return BadRequest("Id mismatch");
            await _playerService.UpdatePlayerAsync(player);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> DeletePlayer(int id)
        {
            await _playerService.DeletePlayerAsync(id);
            return NoContent();
        }
    }
}
