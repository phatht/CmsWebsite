using CmsWebsite.Share.Models.ArticleCategory;
using System.Net.Http.Json;

namespace CmsWebsite.Client.Blazor.Services.ArticleCategory
{
    public class ArticleCategoryService : IArticleCategoryService
    {
        private readonly HttpClient _httpClient;
        public ArticleCategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ArticleCategoryDTO> CreateArticleCategory(ArticleCategoryCreateRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("api/ArticleCategory", request);
            ArticleCategoryDTO result = await response.Content.ReadFromJsonAsync<ArticleCategoryDTO>();
            return result;
        }
    }
}
