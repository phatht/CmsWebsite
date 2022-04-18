using CmsWebsite.Share.Models.Article;
using CmsWebsite.Share.Response;
using Microsoft.AspNetCore.Http;

namespace CmsWebsite.Client.Blazor.Services.Article
{
    public interface IArticleService
    {
        Task<List<ArticleDTO>> GetListArticle();
        Task<ArticleDTO> GetArticle(long id);
        Task<long> CreateArticle(ArticleCreateRequest arRequest);
        Task<bool> UpdateArticle(long id, ArticleDTO article);
        Task<bool> DeleteArticle(long id, bool isDeleted);
        Task<UploadFileResponse> UploadArticleImage(MultipartFormDataContent content);
        Task<bool> DeleteArticleImage(string fileName);

    }
}
