using CmsWebsite.Share.Models.Article;

namespace CmsWebsite.Client.Blazor.Services
{
    public interface IArticleService
    {
        Task<List<ArListDTO>> GetListArticle();
        Task<Article> GetArticle(long id);
        Task<bool> CreateArticle(Article arRequest);
        Task<bool> UpdateArticle(long id, Article arRequest);
        Task<bool> DeleteArticle(long id);
    }
}
