using IceArena.Data.Models;
using IceArena.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IceArena.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitionController : ControllerBase
    {
        private readonly ICompetitionService _competitionService;

        public CompetitionController(ICompetitionService competitionService)
        {
            _competitionService = competitionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var competitions = await _competitionService.GetAllCompetitionsAsync();
            return Ok(competitions);
        }

        [HttpGet("isregistered")]
        [Authorize] 
        public async Task<IActionResult> IsUserRegistered(int userId, int competitionId)
        {
            var isRegistered = await _competitionService.IsUserRegisteredAsync(userId, competitionId);
            return Ok(isRegistered);
        }

        [HttpPost("register")]
        [Authorize]
        public async Task<IActionResult> RegisterUser([FromBody] CompUser compUser)
        {
            await _competitionService.RegisterUserAsync(compUser.IdUser, compUser.IdComp);
            return Ok();
        }
    }
}