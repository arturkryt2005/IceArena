using IceArena.Data.Models;

namespace IceArena.Services.Interfaces
{
    public interface ISubscriptionService
    {
        Task<Subscription?> GetSubscriptionAsync(int id);
        Task<IEnumerable<Subscription>> GetAllSubscriptionsByAsync();
        Task CreateSubscriptionByAsync(Subscription subscription);
        Task UpdateSubscriptionByAsync(Subscription subscription);
        Task DeleteSubscriptionByAsync(int id);
    }
}
