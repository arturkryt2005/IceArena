using IceArena.Data.Models;

namespace IceArena.Data.Repositories.Interfaces
{
    public interface IBookingRepository
    {
        Task<Booking?> GetByIdAsync(int id);
        Task<IEnumerable<Booking>> GetAllAsync();
        Task<IEnumerable<Booking>> GetAvailableSlotsAsync(DateTime date);
        Task<IEnumerable<Booking>> GetAvailableSlotsAsync();
        Task<IEnumerable<Booking>> GetUserBookingsAsync(int userId);
        Task<List<Booking>> GetUserRecentBookingsAsync(int userId);
        Task AddAsync(Booking booking);
        Task UpdateAsync(Booking booking);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}
