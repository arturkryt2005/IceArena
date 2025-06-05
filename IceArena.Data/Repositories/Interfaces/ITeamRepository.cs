using IceArena.Data.Models;

namespace IceArena.Data.Repositories.Interfaces
{
    public interface ITeamRepository
    {
        Task<Team?> GetByIdAsync(int id);
        Task<IEnumerable<Team>> GetAllAsync();
        Task AddAsync(Team team);
        Task UpdateAsync(Team team);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}
