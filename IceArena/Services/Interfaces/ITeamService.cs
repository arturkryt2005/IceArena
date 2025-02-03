using IceArena.Data.Models;

namespace IceArena.Services.Interfaces
{
    public interface ITeamService
    {
        Task<Team?>GetTeamAsync(int id);
        Task<IEnumerable<Team>> GetAllTeamsByAsync();
        Task CreateTeamByAsync(Team team);
        Task UpdateTeamByAsync(Team team);
        Task DeleteTeamByAsync(int id);
    }
}
