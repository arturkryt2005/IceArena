using IceArena.Data.Models;

namespace IceArena.Services.Interfaces
{
    public interface IMatchService
    {
        Task<Match?> GetMatchAsync(int id);
        Task<IEnumerable<Match>> GetAllMatchesAsync();
        Task CreateMatchAsync(Match match);
        Task UpdateMatchAsync(Match match);
        Task DeleteMatchAsync(int id);
    }
}
