using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace IceArena.Data.Models
{
    public class Team
    {
        public int Id { get; set; } 

        public string? Name { get; set; }

        public string? MongoLogoId { get; set; }

        public DateTime CreatedAt { get; set; }

    }
}
