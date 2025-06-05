using System.ComponentModel.DataAnnotations;

namespace IceArena.Data.Requests
{
    public class RegisterRequest
    {
        [Required]
        public string Username { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, MinLength(6)]
        public string Password { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

    }
}
