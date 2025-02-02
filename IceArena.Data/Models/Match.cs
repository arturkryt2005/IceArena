using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceArena.Data.Models
{
    public class Match
    {
        public int Id { get; set; }

        [Required]
        public int Team1Id { get; set; }

        [Required]
        public int Team2Id { get; set; }

        public DateTime MatchDate { get; set; }

        public string? Location { get; set; }

        public string? Result { get; set; }

        public DateTime CreatedAt { get; set; }

        public Team? Team1 { get; set; }

        public Team? Team2 { get; set; }
    }
}
