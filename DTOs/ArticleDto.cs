using System.ComponentModel.DataAnnotations;

namespace BlogAPI.DTOs
{
    public class ArticleCreateDto
    {
        [Required]
        [StringLength(200, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
    }

    public class ArticleUpdateDto
    {
        [Required]
        [StringLength(200, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
    }

    public class ArticleDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
    }
}