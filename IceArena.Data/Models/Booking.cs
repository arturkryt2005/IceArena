using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceArena.Data.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public DateTime Date { get; set; }

        public int Duration { get; set; }

        public string? Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public Team? User { get; set; }
    }
}
