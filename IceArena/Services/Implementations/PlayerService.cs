using IceArena.Data.Models;
using IceArena.Data.Repositories.Interfaces;
using IceArena.Services.Interfaces;

namespace IceArena.Services.Implementations
{
    public class PlayerService:IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<Player?> GetPlayerByAsync(int id)
        {
            return await _playerRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Player>> GetAllPlayersByAsync()
        {
            return await _playerRepository.GetAllAsync();
        }

        public async Task CreatePlayerByAsync(Player player)
        {
            await _playerRepository.AddAsync(player);
            await _playerRepository.SaveChangesAsync();
        }

        public async Task UpdatePlayerAsync(Player player)
        {
            await _playerRepository.UpdateAsync(player);
            await _playerRepository.SaveChangesAsync();
        }

        public async Task DeletePlayerAsync(int id)
        {
            await _playerRepository.DeleteAsync(id);
            await _playerRepository.SaveChangesAsync();
        }
    }
}
