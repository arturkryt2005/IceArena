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
        public int IdUser { get; set; }

        [Column("id_comp")]
        public int IdComp { get; set; }
    }
}
