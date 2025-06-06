using IceArena.Data.Models;
using IceArena.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IceArena.Data.Repositories.Implementations
{
    public class CompetitionRepository : ICompetitionRepository
    {
        private readonly IceArenaDbContext _context;

        public CompetitionRepository(IceArenaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Competitions>> GetAllAsync()
        {
            return await _context.Competitions.ToListAsync();
        }

        public async Task<bool> IsUserRegisteredAsync(int userId, int competitionId)
        {
            return await _context.CompUsers
                .AnyAsync(cu => cu.UserId == userId && cu.CompId == competitionId);
        }

        public async Task RegisterUserAsync(int userId, int competitionId)
        {
            var compUser = new CompUser
            {
                UserId = userId,
                CompId = competitionId
            };

            await _context.CompUsers.AddAsync(compUser);
            await _context.SaveChangesAsync();
        }
    }
}