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
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("team1_id")]
        public int Team1Id { get; set; }

        [Column("team2_id")]
        public int Team2Id { get; set; }

        [Column("match_date")]
        public DateTime MatchDate { get; set; }

        [Column("location")]
        public string? Location { get; set; }

        [Column("result")]
        public string? Result { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        public Team? Team1 { get; set; }

        public Team? Team2 { get; set; }
    }
}
