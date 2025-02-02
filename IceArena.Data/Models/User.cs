using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceArena.Data.Models
{
    public class User
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("username")]
        public string? Username { get; set; }

        [Column("email")]
        public string? Email { get; set; }

        [Column("password_hash")]
        public string? PasswordHash { get; set; }

        [Column("role")]
        public string? Role { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
