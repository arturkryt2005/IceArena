using IceArena.Data.Models;
using IceArena.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace IceArena.Data.Repositories.Implementations
{
    public class PlayerRepository:IPlayerRepository
    {
        private readonly IceArenaDbContext _dbContext;

        public PlayerRepository(IceArenaDbContext iceArenaDbContext) {
            _dbContext = iceArenaDbContext;
        }

        public async Task<Player?> GetByIdAsync(int id) 
        {
            return await _dbContext.Players.FindAsync(id);
        }

        public async Task<IEnumerable<Player>> GetAllAsync()
        {
            return await _dbContext.Players.ToListAsync();
        }

        public async Task AddAsync(Player player)
        {
            await _dbContext.Players.AddAsync(player);
        }

        public async Task UpdateAsync(Player player)
        {
            _dbContext.Players.Update(player);
        }

        public async Task DeleteAsync(int id)
        {
            var player = await _dbContext.Players.FindAsync(id);
            if(player != null) 
            _dbContext.Players.Remove(player);
        }
        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
