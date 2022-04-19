using CmsWebsite.Share.Models.ArticleCategory;

namespace CmsWebsite.Client.Blazor.Services.ArticleCategory
{
    public interface IArticleCategoryService
    {
        Task<ArticleCategoryDTO> GetArticleCategory(long id);
        Task<bool> CreateArticleCategory(ArticleCategoryRequest request);
        Task<bool> UpdateArticleCategory(long articleId, ArticleCategoryDTO ac);

    }
}
