using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IceArena.Data.Models
{
    public class Booking
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("user_id")]
        public int? UserId { get; set; }

        private DateTime _date = DateTime.UtcNow;
        [Column("date")]
        public DateTime Date
        {
            get => _date;
            set => _date = DateTime.SpecifyKind(value, DateTimeKind.Utc);
        }

        private TimeSpan _startTime = TimeSpan.Zero;
        [Column("start_time")]
        public TimeSpan StartTime
        {
            get => _startTime;
            set => _startTime = value;
        }

        private TimeSpan _endTime = TimeSpan.Zero;
        [Column("end_time")]
        public TimeSpan EndTime
        {
            get => _endTime;
            set => _endTime = value;
        }

        [Column("duration")]
        public int Duration { get; set; }

        [Column("status")]
        public string? Status { get; set; }

        private DateTime _createdAt = DateTime.UtcNow;
        [Column("created_at")]
        public DateTime CreatedAt
        {
            get => _createdAt;
            set => _createdAt = DateTime.SpecifyKind(value, DateTimeKind.Utc);
        }

        public User? User { get; set; }
    }
}