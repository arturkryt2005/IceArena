using IceArena.Data.Models;

namespace IceArena.Services.Interfaces
{
    public interface IBookingService
    {
        Task<Booking?> GetBookingAsync(int id);
        Task<IEnumerable<Booking>> GetBookingsAsync();
        Task CreateBooking(Booking booking);
        Task UpdateBooking(Booking booking);
        Task DeleteBooking(int id);
    }
}
