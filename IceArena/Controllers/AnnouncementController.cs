using IceArena.Data.Models;
using IceArena.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IceArena.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;

        public AnnouncementController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnnouncement(int id)
        {
            var announcement = await _announcementService.GetAnnouncementAsync(id);
            return announcement != null ? Ok(announcement) : NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAnnouncements()
        {
            var announcements = await _announcementService.GetAnnouncementsAsync();
            return Ok(announcements);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAnnouncements([FromBody] Announcement announcement)
        {
            await _announcementService.CreateAnnouncement(announcement);
            return CreatedAtAction(nameof(GetAnnouncement), new {id = announcement.Id }, announcement);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAnnouncement(int id, [FromBody] Announcement announcement)
        {
            if (id != announcement.Id) return BadRequest("Id mismatch");
            await _announcementService.UpdateAnnouncement(announcement);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnnouncementAsync(int id)
        {
            await _announcementService.DeleteAnnouncementAsync(id);
            return NoContent();
        }
    }
}
