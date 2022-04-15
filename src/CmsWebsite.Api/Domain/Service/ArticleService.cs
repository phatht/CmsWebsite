using CmsWebsite.Api.Domain.Exceptions;
using CmsWebsite.Api.Domain.Interfaces;
using CmsWebsite.Api.Domain.Models;
using CmsWebsite.Share.Models.Article;

namespace CmsWebsite.Api.Domain.Service
{
    public interface IArticleService
    {
        Task<IEnumerable<Article>> GetArticleAsync();

        Task<Article> GetArticleAsync(long id);
        //create
        Task<long> PutArticleAsync(ArticleCreateRequest request);

        Task<Article> DeleteArticle(long id);

        Task<Article> PutArticleAsync(long id, ArticleDTO article);
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

        public async Task<long> PutArticleAsync(ArticleCreateRequest request)
        {
            try
            {
                var article = new Article()
                {
                    UserId = request.UserId,
                    CreatedDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now,
                    Title = request.Title,
                    Description = request.Description,
                    SummaryArticle = request.SummaryArticle,
                    ImageFile = request.ImageFile,
                    PublishDate = request.PublishDate,
                    ExpireDate = request.PublishDate.AddDays(10),
                    KeyWords = request.KeyWords,
                    SubHead = request.SubHead,
                    Status = 1,
                    taked = true,
                };
                var result = await _unitOfWork.ArticleRepository.AddAsync(article);
                await _unitOfWork.CommitAsync();

                return result.ArticleID;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error when create article {ex}", ex.Message);
                throw;
            }
        }

        public async Task<Article> PutArticleAsync(long id, ArticleDTO article)
        {
            var existingArticle = await _unitOfWork.ArticleRepository.FindAsync(id);

            if (existingArticle == null)
            {
                throw new NotFoundException($"Article {id} is not found."); 
            }

            existingArticle.Description = article.Description;
            existingArticle.Title = article.Title;
            existingArticle.ImageFile = article.ImageFile;
            existingArticle.KeyWords = article.KeyWords;
            existingArticle.SubHead = article.SubHead;
            existingArticle.SummaryArticle = article.SummaryArticle;
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
