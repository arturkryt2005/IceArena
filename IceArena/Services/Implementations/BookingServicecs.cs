using IceArena.Data.Models;
using IceArena.Data.Repositories.Interfaces;
using IceArena.Services.Interfaces;

namespace IceArena.Services.Implementations
{
    public class BookingServicecs: IBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingServicecs(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<Booking?> GetBookingAsync(int id)
        {
            return await _bookingRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Booking>> GetBookingsAsync()
        {
            return await _bookingRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Booking>> GetAvailableSlotsAsync(DateTime date)
        {
            return await _bookingRepository.GetAvailableSlotsAsync(date);
        }

        public async Task<IEnumerable<Booking>> GetAvailablSlotsAsync()
        {
            return await _bookingRepository.GetAvailablSlotsAsync();
        }


        public async Task CreateBooking(Booking booking)
        {
            await _bookingRepository.AddAsync(booking);
            await _bookingRepository.SaveChangesAsync();
        }

        public async Task UpdateBooking(Booking booking)
        {
            await _bookingRepository.UpdateAsync(booking);
            await _bookingRepository.SaveChangesAsync();
        }

        public async Task DeleteBooking(int id)
        {
            await _bookingRepository.DeleteAsync(id);
            await _bookingRepository.SaveChangesAsync();
        }

        public async Task ConfirmBookingAsync(int bookingId, int userId)
        {
            var booking = await _bookingRepository.GetByIdAsync(bookingId);
            if (booking != null && booking.Status == "Available")
            {
                booking.UserId = userId;
                booking.Status = "Pending Approval"; 
                await _bookingRepository.UpdateAsync(booking);
                await _bookingRepository.SaveChangesAsync();
            }
        }
    }
}
