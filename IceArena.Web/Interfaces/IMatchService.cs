using IceArena.Web.Models;

namespace IceArena.Web.Interfaces
{
    public interface IMatchService
    {
        Task<List<MatchDto>> GetMatchesAsync(CancellationToken cancellationToken = default);
    }
}
