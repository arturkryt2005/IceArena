using IceArena.Data.Models;
using IceArena.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceArena.Data.Repositories.Implementations
{
    public class SubscriptionRepository:ISubscriptionRepository
    {
        private readonly IceArenaDbContext _context;

        public SubscriptionRepository(IceArenaDbContext context) {
            _context = context;
        }

        public async Task<Subscription?> GetByIdAsync(int id)
        {
            return await _context.Subscriptions.FindAsync(id);
        }

        public async Task<IEnumerable<Subscription>> GetAllAsync()
        {
            return await _context.Subscriptions.ToListAsync();
        }

        public async Task AddAsync(Subscription subscription)
        {
            await _context.Subscriptions.AddAsync(subscription);
        }

        public async Task UpdateAsync(Subscription subscription)
        {
            _context.Subscriptions.Update(subscription);
        }

        public async Task DeleteAsync(int id)
        {
            var subscription = await _context.Subscriptions.FindAsync(id);
            if (subscription != null)
            {
                _context.Subscriptions.Remove(subscription);
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
