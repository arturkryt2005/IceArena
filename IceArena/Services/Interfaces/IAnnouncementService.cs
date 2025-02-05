using IceArena.Data.Models;

namespace IceArena.Services.Interfaces
{
    public interface IAnnouncementService
    {
        Task<Announcement?> GetAnnouncementAsync(int id);
        Task<IEnumerable<Announcement>> GetAnnouncementsAsync();
        Task CreateAnnouncement(Announcement newAnnouncement);
        Task UpdateAnnouncement(Announcement newAnnouncement);
        Task DeleteAnnouncementAsync(int id);
    }
}
