using CmsWebsite.Api.Domain.Exceptions;
using CmsWebsite.Api.Domain.Interfaces;
using CmsWebsite.Api.Domain.Models;

namespace CmsWebsite.Api.Domain.Service
{
    public interface IArticleService
    {
        Task<IEnumerable<Article>> GetArticleAsync();

        Task<Article> GetArticleAsync(long id);

        Task<Article> PutArticleAsync(Article article);

        Task<Article> DeleteArticle(long id);

        Task<Article> PutArticleAsync(long id, Article article);
    }

    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ArticleService> _logger;

        public ArticleService(IUnitOfWork unitOfWork, ILogger<ArticleService> logger)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Article>> GetArticleAsync()
        { 
            return await _unitOfWork.ArticleRepository.ListAsync();

        }

        public async Task<Article> GetArticleAsync(long id)
        {
 
            return await _unitOfWork.ArticleRepository.FindAsync(id);
        }

        public async Task<Article> PutArticleAsync(Article article)
        {
            try
            {
                var result = await _unitOfWork.ArticleRepository.AddAsync(article);
                await _unitOfWork.CommitAsync();

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error when create article {ex}", ex.Message);
                throw;
            }
        }

        public async Task<Article> PutArticleAsync(long id, Article article)
        {
            var existingArticle = await _unitOfWork.ArticleRepository.FindAsync(id);

            if (existingArticle == null)
            {
                throw new NotFoundException($"Article {id} is not found.");
            }

            existingArticle.Description = article.Description;

            try
            {
                _unitOfWork.ArticleRepository.Update(existingArticle);
                await _unitOfWork.CommitAsync();

                return existingArticle;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error when update article {ex}", ex.Message);
                throw ex;
            }
        }

        public async Task<Article> DeleteArticle(long id)
        {
            var existingArticle = await _unitOfWork.ArticleRepository.FindAsync(id);

            if (existingArticle == null)
            {
                throw new NotFoundException($"Article {id} is not found.");
            }

            try
            {
                _unitOfWork.ArticleRepository.Remove(existingArticle);
                await _unitOfWork.CommitAsync();

                return existingArticle;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error when delete article {ex}", ex.Message);
                throw ex;
            }
        }
    }
}
