﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceArena.Data.Models
{
    public class Announcement
    {
        public int Id { get; set; } 

        public string? Title { get; set; } 

        public string? Content { get; set; } 

        public string? ImageUrl { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
