﻿using IceArena.Data.Models;
using IceArena.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<Booking>> GetUserBookingsAsync(int userId)
        {
            return await _dbContext.Bookings
                .Where(b => b.UserId == userId && b.Status == "Pending" || b.Status == "Booked" || b.Status == "Cancelled")
                .ToListAsync();
        }

        public async Task<IEnumerable<Booking>> GetAvailableSlotsAsync()
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

        public async Task<List<Booking>> GetUserRecentBookingsAsync(int userId)
        {
            var now = DateTime.UtcNow;

            return await _dbContext.Bookings
                .Where(b => b.UserId == userId &&
                            b.Status == "Booked" &&
                            b.CreatedAt >= now.AddHours(-24))
                .ToListAsync();
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
