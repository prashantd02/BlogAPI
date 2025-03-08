using BlogAPI.Data.Repositories;
using BlogAPI.DTOs;
using BlogAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<IEnumerable<ArticleDto>> GetAllArticlesAsync()
        {
            var articles = await _articleRepository.GetAllAsync();
            return articles.Select(a => MapToArticleDto(a));
        }

        public async Task<ArticleDto> GetArticleByIdAsync(int id)
        {
            var article = await _articleRepository.GetByIdAsync(id);

            if (article == null)
            {
                throw new Exception("Article not found");
            }

            return MapToArticleDto(article);
        }

        public async Task<IEnumerable<ArticleDto>> GetArticlesByUserIdAsync(int userId)
        {
            var articles = await _articleRepository.GetByUserIdAsync(userId);
            return articles.Select(a => MapToArticleDto(a));
        }

        public async Task<ArticleDto> CreateArticleAsync(ArticleCreateDto articleDto, int userId)
        {
            var article = new Article
            {
                Title = articleDto.Title,
                Content = articleDto.Content,
                UserId = userId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _articleRepository.CreateAsync(article);

            // Fetch the complete article with user data
            var createdArticle = await _articleRepository.GetByIdAsync(article.Id);
            return MapToArticleDto(createdArticle);
        }

        public async Task<ArticleDto> UpdateArticleAsync(int id, ArticleUpdateDto articleDto, int userId)
        {
            var article = await _articleRepository.GetByIdAsync(id);

            if (article == null)
            {
                throw new Exception("Article not found");
            }

            if (article.UserId != userId)
            {
                throw new Exception("You are not authorized to update this article");
            }

            // Update article properties
            article.Title = articleDto.Title;
            article.Content = articleDto.Content;
            article.UpdatedAt = DateTime.UtcNow;

            await _articleRepository.UpdateAsync(article);

            return MapToArticleDto(article);
        }

        public async Task DeleteArticleAsync(int id, int userId)
        {
            var article = await _articleRepository.GetByIdAsync(id);

            if (article == null)
            {
                throw new Exception("Article not found");
            }

            if (article.UserId != userId)
            {
                throw new Exception("You are not authorized to delete this article");
            }

            await _articleRepository.DeleteAsync(article);
        }

        private ArticleDto MapToArticleDto(Article article)
        {
            return new ArticleDto
            {
                Id = article.Id,
                Title = article.Title,
                Content = article.Content,
                CreatedAt = article.CreatedAt,
                UpdatedAt = article.UpdatedAt,
                UserId = article.UserId,
                Username = article.User?.Username
            };
        }
    }
}