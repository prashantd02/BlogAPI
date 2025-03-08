using System.ComponentModel.DataAnnotations;

namespace BlogAPI.DTOs
{
    public class RegisterDto
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; }

        [StringLength(200)]
        public string FullName { get; set; }
    }

    public class LoginDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }

    public class UserProfileDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public DateTime RegisteredAt { get; set; }
        public int ArticlesCount { get; set; }
    }

    public class AuthResponse
    {
        public string Token { get; set; }
        public UserProfileDto User { get; set; }
    }
}