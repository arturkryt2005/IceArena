using IceArena.Data.Models;
using IceArena.Data.Repositories.Interfaces;
using IceArena.Services.Interfaces;

namespace IceArena.Services.Implementations
{
    public class CompetitionService : ICompetitionService
    {
        private readonly ICompetitionRepository _competitionRepository;

        public CompetitionService(ICompetitionRepository competitionRepository)
        {
            _competitionRepository = competitionRepository;
        }

        public async Task<List<Competitions>> GetAllCompetitionsAsync()
        {
            return await _competitionRepository.GetAllAsync();
        }

        public async Task<bool> IsUserRegisteredAsync(int userId, int competitionId)
        {
            return await _competitionRepository.IsUserRegisteredAsync(userId, competitionId);
        }

        public async Task RegisterUserAsync(int userId, int competitionId)
        {
            await _competitionRepository.RegisterUserAsync(userId, competitionId);
        }
    }
}