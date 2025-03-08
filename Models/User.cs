using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlogAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Username { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [MaxLength(200)]
        public string FullName { get; set; }

        public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;
        public DateTime LastLoginAt { get; set; }

        // Navigation property
        public virtual ICollection<Article> Articles { get; set; }
    }
}