using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceArena.Data.Models
{
    public class Player
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? LastName { get; set; }

        public string? MiddleName { get; set; }

        public int Number { get; set; }

        public string? Position { get; set; }

        public string? MongoPhotoId { get; set; }

        public DateTime CreatedAt { get; set; }

        public int TeamId { get; set; }

        public Team? Team { get; set; }
    }
}
