using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceArena.Data.Models
{
    public class AuthResponse
    {
        public string Token { get; set; } = string.Empty;

        public int UserId { get; set; }

        public string Username { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Role { get; set; } = "user";

        public string PhoneNumber { get; set; } = "";

    }
}
