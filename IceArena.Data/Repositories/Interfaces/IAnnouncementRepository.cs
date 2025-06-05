using IceArena.Data.Models;

namespace IceArena.Data.Repositories.Interfaces
{
    public interface IAnnouncementRepository
    {
        Task<Announcement?> GetByIdAsync(int id);
        Task<IEnumerable<Announcement>> GetAllAsync();
        Task AddAsync(Announcement Announcement);
        Task UpdateAsync(Announcement Announcement);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}
