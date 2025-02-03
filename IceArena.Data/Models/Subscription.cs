using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceArena.Data.Models
{
    public class Subscription
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string? Type { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string? Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public Team? User { get; set; }
    }
}
