using CmsWebsite.Share.Models.Article;

namespace CmsWebsite.Client.Blazor.Services.Article
{
    public interface IArticleService
    {
        Task<List<ArticleDTO>> GetListArticle();
        Task<ArticleDTO> GetArticle(long id);
        Task<long> CreateArticle(ArticleCreateRequest arRequest);
        Task<bool> UpdateArticle(long id, ArticleDTO article);
        Task<bool> DeleteArticle(long id);
    }
}
