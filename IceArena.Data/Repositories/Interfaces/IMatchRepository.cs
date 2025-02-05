using IceArena.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceArena.Data.Repositories.Interfaces
{
    public interface IMatchRepository
    {
        Task<Match?> GetByIdAsync(int id);
        Task<IEnumerable<Match>> GetAllAsync();
        Task AddAsync(Match match);
        Task UpdateAsync(Match match);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}
