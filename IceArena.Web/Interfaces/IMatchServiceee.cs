using IceArena.Web.Models;

namespace IceArena.Web.Interfaces
{
    public interface IMatchServiceee
    {
        Task<List<MatchDto>> GetMatchesAsync(CancellationToken cancellationToken = default);
    }
}
