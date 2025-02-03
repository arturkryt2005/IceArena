using IceArena.Data.Models;
using IceArena.Data.Repositories.Interfaces;
using IceArena.Services.Interfaces;

namespace IceArena.Services.Implementations
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;


        public TeamService(ITeamRepository teamRepository) { 
            _teamRepository = teamRepository;
        }

        public async Task<Team?> GetTeamAsync(int id)
        {
            return await _teamRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Team>> GetAllTeamsByAsync()
        {
            return await _teamRepository.GetAllAsync();
        }

        public async Task CreateTeamByAsync(Team team)
        {
            await _teamRepository.AddAsync(team);
            await _teamRepository.SaveChangesAsync();
        }

        public async Task UpdateTeamByAsync(Team team)
        {
            await _teamRepository.UpdateAsync(team);
            await _teamRepository.SaveChangesAsync();
        }

        public async Task DeleteTeamByAsync(int id)
        {
            await _teamRepository.DeleteAsync(id);
            await _teamRepository.SaveChangesAsync();
        }
    }
}
