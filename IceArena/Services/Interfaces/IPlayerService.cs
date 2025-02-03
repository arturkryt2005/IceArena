using IceArena.Data.Models;

namespace IceArena.Services.Interfaces
{
    public interface IPlayerService
    {
        Task<Player?> GetPlayerByAsync(int id);
        Task <IEnumerable<Player>> GetAllPlayersByAsync();
        Task CreatePlayerByAsync(Player player);
        Task UpdatePlayerAsync(Player player);
        Task DeletePlayerAsync(int id);
    }
}
