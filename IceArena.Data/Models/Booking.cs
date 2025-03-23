using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace IceArena.Data.Models
{
    public class Booking
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("user_id")]
        public int? UserId { get; set; }

        private DateTime _date;
        [Column("date" )]
        public DateTime Date
        {
            get => _date.ToUniversalTime();
            set => _date = DateTime.SpecifyKind(value, DateTimeKind.Utc);  
        }

        [Column("start_time")]
        public TimeSpan StartTime { get; set; }

        [Column("end_time")]
        public TimeSpan EndTime { get; set; }

        [Column("duration")]
        public int Duration { get; set; }

        [Column("status")]
        public string? Status { get; set; }

        private DateTime _createdAt;
        [Column("created_at")]
        public DateTime CreatedAt
        {
            get => _createdAt.ToUniversalTime();  
            set => _createdAt = DateTime.SpecifyKind(value, DateTimeKind.Utc);  
        }

        public User? User { get; set; }
    }
}
