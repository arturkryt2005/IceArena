using IceArena.Data.Models;
using IceArena.Data.Repositories.Interfaces;
using IceArena.Services.Interfaces;
using System.Web.Http;

namespace IceArena.Services.Implementations
{
    public class SubscriptionService:ISubscriptionService
    {
        private readonly ISubscriptionRepository _subscriptionRepository;

        public SubscriptionService(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task<Subscription?> GetSubscriptionAsync(int id)
        {
            return await _subscriptionRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Subscription>> GetAllSubscriptionsByAsync()
        {
            return await _subscriptionRepository.GetAllAsync();
        }

        public async Task CreateSubscriptionByAsync(Subscription subscription)
        {
            await _subscriptionRepository.AddAsync(subscription);
            await _subscriptionRepository.SaveChangesAsync();
        }

        public async Task UpdateSubscriptionByAsync(Subscription subscription)
        {
            await _subscriptionRepository.UpdateAsync(subscription);
            await _subscriptionRepository.SaveChangesAsync();
        }

        public async Task DeleteSubscriptionByAsync(int id)
        {
            await _subscriptionRepository.DeleteAsync(id);
            await _subscriptionRepository.SaveChangesAsync();
        }
    }
}
