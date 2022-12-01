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
        public async Task<bool> CreateArticleCategory(ArticleCategoryRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("api/ArticleCategory", request);
            return response.IsSuccessStatusCode;
        }

        public async Task<ArticleCategoryDTO> GetArticleCategory(Guid id)
        {
            var response = await _httpClient.GetFromJsonAsync<ArticleCategoryDTO>($"api/ArticleCategory/{id}");
            return response;
        }

        public async Task<bool> UpdateArticleCategory(Guid articleId, ArticleCategoryDTO ac)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/ArticleCategory/{articleId}", ac);
            return response.IsSuccessStatusCode;
        }
    }
}
