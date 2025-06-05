using IceArena.Data.Models;

namespace IceArena.Services.Interfaces
{
    public interface ICompetitionService
    {
        Task<List<Competitions>> GetAllCompetitionsAsync();
        Task<bool> IsUserRegisteredAsync(int userId, int competitionId);
        Task RegisterUserAsync(int userId, int competitionId);
    }
}
