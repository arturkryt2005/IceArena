using IceArena.Data.Models;
using IceArena.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Match = IceArena.Data.Models.Match;

namespace IceArena.Data.Repositories.Implementations
{
    public class MatchRepository:IMatchRepository
    {
        private readonly IceArenaDbContext _dbContext;

        public MatchRepository(IceArenaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Match?> GetByIdAsync(int id)
        {
            return await _dbContext.Matches.FindAsync(id);
        }

        public async Task<IEnumerable<Match>> GetAllAsync()
        {
            return await _dbContext.Matches.ToListAsync();
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
