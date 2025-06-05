using IceArena.Data.Models;
using IceArena.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IceArena.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBooking(int id)
        {
            var booking = await _bookingService.GetBookingAsync(id);
            return booking != null ? Ok(booking) : NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetBookings()
        {
            var bookings = await _bookingService.GetBookingsAsync();
            return Ok(bookings);
        }

        [HttpGet("available/{date}")]
        public async Task<IActionResult> GetAvailableSlots([FromRoute] DateTime date)
        {
            DateTime utcDate = date.Kind == DateTimeKind.Unspecified
                ? DateTime.SpecifyKind(date, DateTimeKind.Utc)
                : date.ToUniversalTime();

            var slots = await _bookingService.GetAvailableSlotsAsync(utcDate);
            return Ok(slots);
        }

        [HttpGet("available")]
        public async Task<IActionResult> GetAvailableSlots()
        {
            var slots = await _bookingService.GetAvailableSlotsAsync();
            return Ok(slots);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] Booking booking)
        {
            if (booking == null)
            {
                return BadRequest("Данные бронирования не указаны.");
            }

            if (booking.CreatedAt == DateTime.MinValue)
                booking.CreatedAt = DateTime.UtcNow;

            if (booking.StartTime == TimeSpan.Zero)
                booking.StartTime = booking.Date.TimeOfDay;

            if (booking.EndTime == TimeSpan.Zero)
            {
                booking.EndTime = booking.StartTime.Add(TimeSpan.FromMinutes(booking.Duration));
            }

            if (string.IsNullOrEmpty(booking.Status))
                booking.Status = "Pending";

            await _bookingService.CreateBooking(booking);
            return CreatedAtAction(nameof(GetBooking), new { id = booking.Id }, booking);
        }

        [HttpPost("confirm/{bookingId}/{userId}")]
        public async Task<IActionResult> ConfirmBooking(int bookingId, int userId)
        {
            await _bookingService.ConfirmBookingAsync(bookingId, userId);
            return NoContent();
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserBookings(int userId)
        {
            var bookings = await _bookingService.GetUserBookingsAsync(userId);
            return Ok(bookings);
        }
    }
}