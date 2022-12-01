using CmsWebsite.Share.Models.ArticleCategory;

namespace CmsWebsite.Client.Blazor.Services.ArticleCategory
{
    public interface IArticleCategoryService
    {
        Task<ArticleCategoryDTO> GetArticleCategory(Guid id);
        Task<bool> CreateArticleCategory(ArticleCategoryRequest request);
        Task<bool> UpdateArticleCategory(Guid articleId, ArticleCategoryDTO ac);

    }
}
