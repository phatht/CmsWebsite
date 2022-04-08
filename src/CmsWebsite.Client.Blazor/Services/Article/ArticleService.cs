using CmsWebsite.Share.Models.Article;
using System.Net.Http.Json;

namespace CmsWebsite.Client.Blazor.Services.Article
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
            var result = await _httpClient.PostAsJsonAsync("api/article", arRequest);
            return result.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteArticle(long id)
        {
            var result = await _httpClient.DeleteAsync($"/api/article/{id}");
            return result.IsSuccessStatusCode;
        }

        public async Task<ArticleDTO> GetArticle(long id)
        {
            var result = await _httpClient.GetFromJsonAsync<ArticleDTO>($"api/article/{id}");
            return result;
        }

        public async Task<List<ArticleDTO>> GetListArticle()
        {
            var result = await _httpClient.GetFromJsonAsync<List<ArticleDTO>>("api/article");
            return result;
        }

        public async Task<bool> UpdateArticle(long id, ArticleDTO article)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/article/{id}", article);
            return result.IsSuccessStatusCode;
        }
    }
}
