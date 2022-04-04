using CmsWebsite.Share.Models.Article;

namespace CmsWebsite.Client.Blazor.Services
{
    public interface IArticleService
    {
        Task<List<ListDTO>> GetListArticle();

        Task<bool> CreateArticle(CreateArticleRequest request);
    }
}
