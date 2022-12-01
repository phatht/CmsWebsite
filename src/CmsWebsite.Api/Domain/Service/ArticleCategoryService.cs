using CmsWebsite.Api.Domain.Exceptions;
using CmsWebsite.Api.Domain.Interfaces;
using CmsWebsite.Api.Domain.Models;
using CmsWebsite.Share.Models.ArticleCategory;

namespace CmsWebsite.Api.Domain.Service
{
    public interface IArticleCategoryService
    {
        Task<IEnumerable<ArticleCategories>> GetArticleCategoryByCategoryIdAsync(Guid CategoryId);

        Task<ArticleCategories> GetArticleCategory(Guid id);
        //create
        Task<ArticleCategories> PutArticleCategory(ArticleCategoryRequest request);

        //Task<Article> DeleteArticle(long id);

        Task<ArticleCategories> PutArticleCategory(Guid articleId, ArticleCategories ac);
    }

    public class ArticleCategoryService : IArticleCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ArticleCategoryService> _logger;

        public ArticleCategoryService(IUnitOfWork unitOfWork, ILogger<ArticleCategoryService> logger)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }


        public async Task<IEnumerable<ArticleCategories>> GetArticleCategoryByCategoryIdAsync(Guid CategoryId)
        {
            try
            {
                return await _unitOfWork.ArticleCategoryRepository.ListByCategoryIdAsync(CategoryId);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error when ArticleCategory {ex}", ex.Message);
                throw;
            }
        }

        public async Task<ArticleCategories> PutArticleCategory(ArticleCategoryRequest request)
        {
            try
            {
                var ac = new ArticleCategories()
                {
                    ID = Guid.NewGuid(),
                    ArticleID = request.ArticleID,
                    CategoryID = request.CategoryID
                };
                var result = await _unitOfWork.ArticleCategoryRepository.AddAsync(ac);
                await _unitOfWork.CommitAsync();

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error when create article {ex}", ex.Message);
                throw;
            }
        }
        public async Task<ArticleCategories> GetArticleCategory(Guid id)
        {
            var ac = await _unitOfWork.ArticleCategoryRepository.FindAsync(id);
            if (ac == null)
            {
                return new ArticleCategories()
                {
                    ArticleID = id,
                    CategoryID = null,
                };
            }
            return ac;
        }

        public async Task<ArticleCategories> PutArticleCategory(Guid articleId, ArticleCategories ac)
        {
            var existingAC = await GetArticleCategory(articleId);

            if (existingAC == null)
            {
                throw new NotFoundException($"Article {articleId} is not found.");
            }
            existingAC.CategoryID = ac.CategoryID;
            try
            {
                _unitOfWork.ArticleCategoryRepository.Update(existingAC);
                await _unitOfWork.CommitAsync();

                return existingAC;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error when update article {ex}", ex.Message);
                throw ex;
            }
        }


    }

}
