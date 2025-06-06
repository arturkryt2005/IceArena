using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IceArena.Data.Models
{
    public class CompUser
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("id_user")]
        public int UserId { get; set; }

        public virtual User User { get; set; }

        [Column("id_comp")]
        public int CompId { get; set; }

        public virtual Competitions Comp { get; set; }
    }
}
