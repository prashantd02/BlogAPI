using BlogAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogAPI.Data.Repositories
{
    public interface IArticleRepository
    {
        Task<IEnumerable<Article>> GetAllAsync();
        Task<Article> GetByIdAsync(int id);
        Task<IEnumerable<Article>> GetByUserIdAsync(int userId);
        Task<Article> CreateAsync(Article article);
        Task UpdateAsync(Article article);
        Task DeleteAsync(Article article);
    }
}