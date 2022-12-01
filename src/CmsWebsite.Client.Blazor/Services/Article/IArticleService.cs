using CmsWebsite.Share.Models.Article;
using CmsWebsite.Share.Response;
using Microsoft.AspNetCore.Http;

namespace CmsWebsite.Client.Blazor.Services.Article
{
    public interface IArticleService
    {
        Task<List<ArticleDTO>> GetListArticle();
        Task<List<ArticleDTO>> GetListArticleCategoryByCategoryId(Guid CategoryId);
        Task<ArticleDTO> GetArticle(Guid id);
        Task<ArticleUpdateRequest> GetUpdateArticle(Guid id);
        Task<Guid> CreateArticle(ArticleCreateRequest request);
        Task<bool> UpdateArticle(Guid id, ArticleUpdateRequest request);
        Task<bool> DeleteArticle(Guid id, bool isDeleted);
        Task<bool> DeleteArticleFile(string fileName);
        Task<UploadFileResponse> UploadArticleFile(MultipartFormDataContent content);
        Task LikeArticle(Guid id, bool like);
        Task<List<ArticleDTO>> GetArticlesFromSearch(string ws);
    }
}
