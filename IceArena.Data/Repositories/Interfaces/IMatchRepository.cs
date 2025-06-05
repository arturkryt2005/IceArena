using IceArena.Data.Models;

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
