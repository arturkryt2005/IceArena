using IceArena.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
