using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IceArena.Data.Models
{
    public class Team
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string? Name { get; set; }

        [Column("mongo_logo_id")]
        public string? MongoLogoId { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

    }
}
