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

        [Required(ErrorMessage = "Команда 1 обязательна.")]
        [Column("team1_id")]
        public int Team1Id { get; set; }

        [Required(ErrorMessage = "Команда 2 обязательна.")]
        [Column("team2_id")]
        public int Team2Id { get; set; }

        [Required(ErrorMessage = "Дата и время матча обязательны.")]
        [Column("match_date")]
        public DateTime? MatchDate { get; set; }

        [Required(ErrorMessage = "Место проведения обязательно.")]
        [StringLength(100, ErrorMessage = "Место проведения не может быть длиннее 100 символов.")]
        [Column("location")]
        public string? Location { get; set; }

        [Required(ErrorMessage = "Результат обязателен.")]
        [StringLength(50, ErrorMessage = "Результат не может быть длиннее 50 символов.")]
        [Column("result")]
        public string? Result { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        public Team? Team1 { get; set; }

        public Team? Team2 { get; set; }
    }
}
