using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IceArena.Data.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Имя пользователя обязательно.")]
        [MaxLength(50, ErrorMessage = "Имя пользователя не должно превышать 50 символов.")]
        [MinLength(3, ErrorMessage = "Имя пользователя должно содержать минимум 3 символа.")]
        [RegularExpression(@"^\S*$", ErrorMessage = "Имя пользователя не должно содержать пробелов.")]
        [Column("username")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Email обязателен.")]
        [EmailAddress(ErrorMessage = "Некорректный формат email.")]
        [MaxLength(100, ErrorMessage = "Email не должен превышать 100 символов.")]
        [RegularExpression(@"^\S*$", ErrorMessage = "Email не должен содержать пробелов.")]
        [Column("email")]
        public string? Email { get; set; }

        [Column("password_hash")]
        public string? PasswordHash { get; set; }

        [Required(ErrorMessage = "Роль обязательна.")]
        [MaxLength(20, ErrorMessage = "Роль не должна превышать 20 символов.")]
        [RegularExpression(@"^\S*$", ErrorMessage = "Роль не должна содержать пробелов.")]
        [Column("role")]
        public string? Role { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("phone_number")]
        public string? PhoneNumber { get; set; }
    }
}