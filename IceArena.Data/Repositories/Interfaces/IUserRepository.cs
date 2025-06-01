using IceArena.Data.Models;

namespace IceArena.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(int id);
        Task<User?> GetUserByEmailAsync(string email);
        Task<User> GetUserByPhoneAsync(string phone);
        Task<IEnumerable<User>> GetAllAsync();
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}
