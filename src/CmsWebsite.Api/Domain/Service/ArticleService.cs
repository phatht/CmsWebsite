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

        Task<Article> PutArticleAsync(long id, ArticleUpdateRequest request);

        Task<Article> SoftDeleteArticle(long id, bool isDeleted);

        Task<IEnumerable<Article>> GetArticleByCategoryIdAsync(long CategoryId);

        Task<int> PostLikeArticle(long id, bool like);

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
                    KeyWords = request.KeyWords ?? request.Title,
                    SubHead = request.SubHead ?? request.Title,
                    Author = request.Author ?? "Quản trị viên",
                    Status = 1,
                    PublishDate = DateTime.Now,
                    ExpireDate = DateTime.Now,
                    NumberOfViews = 0,
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

        public async Task<Article> PutArticleAsync(long id, ArticleUpdateRequest request)
        {
            var existingArticle = await GetArticleAsync(id);

            if (existingArticle == null)
            {
                throw new NotFoundException($"Article {id} is not found.");
            }

            existingArticle.Description = request.Description;
            existingArticle.Title = request.Title;
            existingArticle.ImageFile = request.ImageFile;
            existingArticle.KeyWords = request.KeyWords;
            existingArticle.SubHead = request.SubHead;
            existingArticle.SummaryArticle = request.SummaryArticle;
            existingArticle.LastModifiedDate = DateTime.Now;
            existingArticle.Author = request.Author;
            existingArticle.Video = request.Video;
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

        public async Task<Article> SoftDeleteArticle(long id, bool isDeleted)
        {
            var existingArticle = await _unitOfWork.ArticleRepository.FindAsync(id);

            if (existingArticle == null)
            {
                throw new NotFoundException($"Article {id} is not found.");
            }
            existingArticle.isDeleted = isDeleted;
            if (isDeleted)
            {
                existingArticle.DateDeleted = DateTime.Now;
            }
            else
            {
                existingArticle.DateDeleted = null;
            }
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

        public async Task<IEnumerable<Article>> GetArticleByCategoryIdAsync(long CategoryId)
        {
            try
            {
                var articleCategorys = await _unitOfWork.ArticleCategoryRepository.ListByCategoryIdAsync(CategoryId);
                var articles = await _unitOfWork.ArticleRepository.ListAsync();
                var datas = (
                    from a in articles
                    join b in articleCategorys
                    on a.ArticleID equals b.ArticleID
                    select a
                    );

                return datas;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error when get ArticleByCategoryId {ex}", ex.Message);
                throw;
            }

        }

        public async Task<int> PostLikeArticle(long id, bool like)
        {
            try
            {
                var entity = await _unitOfWork.ArticleRepository.FindAsync(id);
                if (like == true)
                    entity.Like += 1;
                else
                    entity.Like -= 1;
                await _unitOfWork.CommitAsync();
                return entity.Like;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error when get ArticleByCategoryId {ex}", ex.Message);
                throw;
            }
        }
    }
}
