using IceArena.Data.Models;
using IceArena.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IceArena.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : Controller
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
        public async Task<IActionResult> GetAllBookings()
        {
            var bookings = await _bookingService.GetBookingsAsync();
            return Ok(bookings);
        }

        [HttpPost]
        public async Task<IActionResult> AddBooking([FromBody] Booking booking)
        {
            await _bookingService.CreateBooking(booking);
            return CreatedAtAction(nameof(AddBooking), new {id = booking.Id}, booking);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBooking(int id, [FromBody] Booking booking)
        {
            if(id != booking.Id) return BadRequest("ID mismatch");
            await _bookingService.UpdateBooking(booking);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            await _bookingService.DeleteBooking(id);
            return NoContent();
        }
    }
}
