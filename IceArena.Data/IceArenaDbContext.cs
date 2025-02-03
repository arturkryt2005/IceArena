using IceArena.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Numerics;
using System.Text.RegularExpressions;
using Match = IceArena.Data.Models.Match;

namespace IceArena.Data
{
    public class IceArenaDbContext:DbContext
    {
        public IceArenaDbContext(DbContextOptions<IceArenaDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Announcement> Announcements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<Team>().ToTable("teams");
            modelBuilder.Entity<Player>().ToTable("players");
            modelBuilder.Entity<Match>().ToTable("matches");
            modelBuilder.Entity<Booking>().ToTable("bookings");
            modelBuilder.Entity<Subscription>().ToTable("subscriptions");
            modelBuilder.Entity<Announcement>().ToTable("announcements");

        }
    }

}
