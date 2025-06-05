using IceArena.Data.Models;
using IceArena.Data.Repositories.Interfaces;
using IceArena.Services.Interfaces;

namespace IceArena.Services.Implementations
{
    public class MatchService:IMatchService
    {
        private readonly IMatchRepository _matchRepository;

        public MatchService(IMatchRepository matchRepository)
        {
            _matchRepository = matchRepository;
        }

        public async Task<Match?> GetMatchAsync(int id)
        {
            return await _matchRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Match>> GetAllMatchesAsync()
        {
            return await _matchRepository.GetAllAsync();
        }

        public async Task CreateMatchAsync(Match match)
        {
            await _matchRepository.AddAsync(match);
            await _matchRepository.SaveChangesAsync();
        }

        public async Task UpdateMatchAsync(Match match)
        {
            Console.WriteLine($"Updating match with ID: {match.Id}");
            await _matchRepository.UpdateAsync(match);
            await _matchRepository.SaveChangesAsync();
        }

        public async Task DeleteMatchAsync(int id)
        {
            await _matchRepository.DeleteAsync(id);
            await _matchRepository.SaveChangesAsync();
        }
    }
}
