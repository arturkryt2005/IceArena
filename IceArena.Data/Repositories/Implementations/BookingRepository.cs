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
    public class BookingRepository:IBookingRepository
    {
        private readonly IceArenaDbContext _dbContext;

        public BookingRepository(IceArenaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Booking>> GetAvailableSlotsAsync(DateTime date)
        {
            DateTime utcDate = date.Kind == DateTimeKind.Unspecified
                ? DateTime.SpecifyKind(date, DateTimeKind.Utc)
                : date.ToUniversalTime();

            return await _dbContext.Bookings
                .Where(b => b.Date.Date == utcDate.Date && b.Status == "Available")
                .ToListAsync();
        }

        public async Task<IEnumerable<Booking>> GetAvailablSlotsAsync()
        {
            return await _dbContext.Bookings
                .Where(b => b.Status == "Available")
                .ToListAsync();
        }

        public async Task<Booking?> GetByIdAsync(int id)
        {
            return await _dbContext.Bookings.FindAsync(id); 
        }

        public async Task<IEnumerable<Booking>> GetAllAsync()
        {
            return await _dbContext.Bookings.ToListAsync();
        }

        public async Task AddAsync(Booking booking)
        {
            await _dbContext.Bookings.AddAsync(booking);
        }

        public async Task UpdateAsync(Booking booking)
        {
            _dbContext.Bookings.Update(booking);
        }

        public async Task DeleteAsync(int id)
        {
            var booking = await _dbContext.Bookings.FindAsync(id);
            if (booking != null) 
            _dbContext.Bookings.Remove(booking);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
