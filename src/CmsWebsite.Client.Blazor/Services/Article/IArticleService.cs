using CmsWebsite.Share.Models.Article;
using CmsWebsite.Share.Response;
using Microsoft.AspNetCore.Http;

namespace CmsWebsite.Client.Blazor.Services.Article
{
    public interface IArticleService
    {
        Task<List<ArticleDTO>> GetListArticle();
        Task<List<ArticleDTO>> GetListArticleCategoryByCategoryId(long CategoryId);
        Task<ArticleDTO> GetArticle(long id);
        Task<ArticleUpdateRequest> GetUpdateArticle(long id);
        Task<long> CreateArticle(ArticleCreateRequest request);
        Task<bool> UpdateArticle(long id, ArticleUpdateRequest request);
        Task<bool> DeleteArticle(long id, bool isDeleted);
        Task<bool> DeleteArticleFile(string fileName);
        Task<UploadFileResponse> UploadArticleFile(MultipartFormDataContent content);
        Task LikeArticle(long id, bool like);
        Task<List<ArticleDTO>> GetArticlesFromSearch(string ws);
    }
}
