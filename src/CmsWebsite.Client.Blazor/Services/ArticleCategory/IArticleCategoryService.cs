using CmsWebsite.Share.Models.ArticleCategory;

namespace CmsWebsite.Client.Blazor.Services.ArticleCategory
{
    public interface IArticleCategoryService
    {
        Task<ArticleCategoryDTO> CreateArticleCategory(ArticleCategoryCreateRequest request);
    }
}
