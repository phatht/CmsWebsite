using CmsWebsite.Share.Models.Article;

namespace CmsWebsite.Client.Blazor.Services
{
    public interface IArticleService
    {
        Task<List<ArListRepositorie>> GetListArticle();
        Task<ArticleCreateRequest> GetArticle(long id);
        Task<bool> CreateArticle(ArticleCreateRequest arRequest);
        Task<bool> UpdateArticle(long id, ArticleCreateRequest arRequest);
        Task<bool> DeleteArticle(long id);
    }
}
