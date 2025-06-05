using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IceArena.Data.Models
{
    public class Player
    {
        [Key]
        [Column ("id")]
        public int Id { get; set; }

        [Column("name")]
        public string? Name { get; set; }

        [Column("last_name")]
        public string? LastName { get; set; }

        [Column("middle_name")]
        public string? MiddleName { get; set; }

        [Column("number")]
        public int Number { get; set; }

        [Column("position")]
        public string? Position { get; set; }

        [Column("mongo_photo_id")]
        public string? MongoPhotoId { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("team_id")]
        public int TeamId { get; set; }

        public Team? Team { get; set; }
    }
}
