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

        public async Task<bool> CreateArticle(Article arRequest)
        {
            var result = await _httpClient.PostAsJsonAsync("api/article",arRequest);
            return result.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteArticle(long id)
        {
            var result = await _httpClient.DeleteAsync($"/api/article/{id}");
            return result.IsSuccessStatusCode;
        }

        public async Task<Article> GetArticle(long id)
        {
            var result = await _httpClient.GetFromJsonAsync<Article>($"api/article/{id}");
            return result;
        }

        public async Task<List<ArListDTO>> GetListArticle()
        {
            var result = await _httpClient.GetFromJsonAsync<List<ArListDTO>>("api/article");
            return result;
        }

        public async Task<bool> UpdateArticle(long id, Article arRequest)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/article/{id}",arRequest);
            return result.IsSuccessStatusCode;
        }
    }
}
