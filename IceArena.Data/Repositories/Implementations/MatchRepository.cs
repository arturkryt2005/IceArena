using IceArena.Data.Models;
using IceArena.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IceArena.Data.Repositories.Implementations
{
    public class MatchRepository : IMatchRepository
    {
        private readonly IceArenaDbContext _dbContext;

        public MatchRepository(IceArenaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Match?> GetByIdAsync(int id)
        {
            return await _dbContext.Matches
                .Include(m => m.Team1)
                .Include(m => m.Team2)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Match>> GetAllAsync()
        {
            return await _dbContext.Matches
                .Include(m => m.Team1)
                .Include(m => m.Team2)
                .ToListAsync();
        }

        public async Task AddAsync(Match match)
        {
            await _dbContext.Matches.AddAsync(match);
        }

        public async Task UpdateAsync(Match match)
        {
            _dbContext.Matches.Update(match);
        }

        public async Task DeleteAsync(int id)
        {
            var match = await _dbContext.Matches.FindAsync(id);
            if (match != null)
                _dbContext.Matches.Remove(match);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}