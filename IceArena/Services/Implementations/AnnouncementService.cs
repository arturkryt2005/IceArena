using IceArena.Data.Models;
using IceArena.Data.Repositories.Interfaces;
using IceArena.Services.Interfaces;

namespace IceArena.Services.Implementations
{
    public class AnnouncementService: IAnnouncementService
    {
        private readonly IAnnouncementRepository _announcementRepository;

        public AnnouncementService(IAnnouncementRepository announcementRepository)
        {
            _announcementRepository = announcementRepository;
        }

        public async Task<Announcement?> GetAnnouncementAsync(int id)
        {
            return await _announcementRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Announcement>> GetAnnouncementsAsync()
        {
            return await _announcementRepository.GetAllAsync();
        }

        public async Task CreateAnnouncement(Announcement announcement)
        {
            await _announcementRepository.AddAsync(announcement);
            await _announcementRepository.SaveChangesAsync();
        }

        public async Task UpdateAnnouncement(Announcement announcement)
        {
            await _announcementRepository.UpdateAsync(announcement);
            await _announcementRepository.SaveChangesAsync();
        }

        public async Task DeleteAnnouncementAsync(int id)
        {
            await _announcementRepository.DeleteAsync(id);
            await _announcementRepository.SaveChangesAsync();
        }
    }
}
