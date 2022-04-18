using CmsWebsite.Share.Models.ArticleCategory;

namespace CmsWebsite.Client.Blazor.Services.ArticleCategory
{
    public interface IArticleCategoryService
    {
        Task<ArticleCategoryDTO> CreateArticleCategory(ArticleCategoryRequest request);
        Task<ArticleCategoryDTO> UpdateArticleCategory(ArticleCategoryRequest request);

    }
}
