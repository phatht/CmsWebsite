using CmsWebsite.Share.Models.Article;
using System.Net.Http.Json;

namespace CmsWebsite.Client.Blazor.Services
{
    public class ArticleService : IArticleService
    {
        private readonly HttpClient _httpClient;
        public ArticleService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateArticle(ArticleCreateRequest arRequest)
        {
            var result = await _httpClient.PostAsJsonAsync("api/article",arRequest);
            return result.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteArticle(long id)
        {
            var result = await _httpClient.DeleteAsync($"/api/article/{id}");
            return result.IsSuccessStatusCode;
        }

        public async Task<ArticleCreateRequest> GetArticle(long id)
        {
            var result = await _httpClient.GetFromJsonAsync<ArticleCreateRequest>($"api/article/{id}");
            return result;
        }

        public async Task<List<ArListRepositorie>> GetListArticle()
        {
            var result = await _httpClient.GetFromJsonAsync<List<ArListRepositorie>>("api/article");
            return result;
        }

        public async Task<bool> UpdateArticle(long id, ArticleCreateRequest arRequest)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/article/{id}",arRequest);
            return result.IsSuccessStatusCode;
        }
    }
}
