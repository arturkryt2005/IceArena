using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        [Column("mongo_image_id")]
        public string? ImageUrl { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
