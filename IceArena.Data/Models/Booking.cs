using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceArena.Data.Models
{
    public class Booking
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [Column("date")]
        public DateTime Date { get; set; }

        [Column("duration")]
        public int Duration { get; set; }

        [Column("status")]
        public string? Status { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        public Team? User { get; set; }
    }
}
