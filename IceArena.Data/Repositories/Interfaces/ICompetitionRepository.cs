using IceArena.Data.Models;

namespace IceArena.Data.Repositories.Interfaces
{
    public interface ICompetitionRepository
    {
        Task<List<Competitions>> GetAllAsync();
        Task<bool> IsUserRegisteredAsync(int userId, int competitionId);
        Task RegisterUserAsync(int userId, int competitionId);
    }
}
