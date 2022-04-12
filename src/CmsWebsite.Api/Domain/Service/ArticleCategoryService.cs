using CmsWebsite.Api.Domain.Interfaces;
using CmsWebsite.Api.Domain.Models;
using CmsWebsite.Share.Models.ArticleCategory;

namespace CmsWebsite.Api.Domain.Service
{
    public interface IArticleCategoryService
    {
        //Task<IEnumerable<Article>> GetArticleAsync();

        //Task<Article> GetArticleAsync(long id);
        //create
        Task<ArticleCategories> PutArticleAsync(ArticleCategoryCreateRequest request);

        //Task<Article> DeleteArticle(long id);

        //Task<Article> PutArticleAsync(long id, ArticleDTO article);
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



        public async Task<ArticleCategories> PutArticleAsync(ArticleCategoryCreateRequest request)
        {
            try
            {
                var ac = new ArticleCategories()
                {
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

    }

}
