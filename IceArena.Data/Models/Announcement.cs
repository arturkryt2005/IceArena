using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IceArena.Data.Models
{
    public class Announcement
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("title")]
        public string? Title { get; set; }

        [Column("content")]
        public string? Content { get; set; }

        [Column("image_data")]
        public byte[] ImageData { get; set; }

        [Column("image_content_type")]
        [StringLength(50)]
        public string ImageContentType { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
