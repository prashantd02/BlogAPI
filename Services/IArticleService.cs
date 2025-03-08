using BlogAPI.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogAPI.Services
{
    public interface IArticleService
    {
        Task<IEnumerable<ArticleDto>> GetAllArticlesAsync();
        Task<ArticleDto> GetArticleByIdAsync(int id);
        Task<IEnumerable<ArticleDto>> GetArticlesByUserIdAsync(int userId);
        Task<ArticleDto> CreateArticleAsync(ArticleCreateDto articleDto, int userId);
        Task<ArticleDto> UpdateArticleAsync(int id, ArticleUpdateDto articleDto, int userId);
        Task DeleteArticleAsync(int id, int userId);
    }
}