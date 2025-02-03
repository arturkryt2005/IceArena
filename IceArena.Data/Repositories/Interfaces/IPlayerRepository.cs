using IceArena.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceArena.Data.Repositories.Interfaces
{
    public interface IPlayerRepository
    {
        Task<Player?> GetByIdAsync(int id);
        Task<IEnumerable<Player>> GetAllAsync();
        Task AddAsync(Player player);
        Task UpdateAsync(Player player);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}
