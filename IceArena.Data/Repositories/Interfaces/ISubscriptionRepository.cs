using IceArena.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceArena.Data.Repositories.Interfaces
{
    public interface ISubscriptionRepository
    {
        Task<Subscription?> GetByIdAsync(int id);
        Task<IEnumerable<Subscription>> GetAllAsync();
        Task AddAsync(Subscription subscription);
        Task UpdateAsync(Subscription subscription);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}
