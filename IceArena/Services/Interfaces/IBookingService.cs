using IceArena.Data.Models;

namespace IceArena.Services.Interfaces
{
    public interface IBookingService
    {
        Task<Booking?> GetBookingAsync(int id);
        Task<IEnumerable<Booking>> GetBookingsAsync();
        Task<IEnumerable<Booking>> GetAvailableSlotsAsync(DateTime date);
        Task<IEnumerable<Booking>> GetUserBookingsAsync(int userId);
        Task<IEnumerable<Booking>> GetAvailableSlotsAsync();
        Task CreateBooking(Booking booking);
        Task UpdateBookingAsync(Booking booking);
        Task DeleteBooking(int id);
        Task ConfirmBookingAsync(int bookingId, int userId);
        Task SaveChangesAsync();
        Task<List<Booking>> GetUserRecentBookingsAsync(int userId);
    }
}
