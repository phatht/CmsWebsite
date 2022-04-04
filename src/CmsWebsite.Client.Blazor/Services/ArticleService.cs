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

        public async Task<bool> CreateArticle(CreateArticleRequest request)
        {
            var result = await _httpClient.PostAsJsonAsync("api/article",request);
            return result.IsSuccessStatusCode;
        }

        public async Task<List<ListDTO>> GetListArticle()
        {
            var result = await _httpClient.GetFromJsonAsync<List<ListDTO>>("api/article");
            return result;
        }
    }
}
