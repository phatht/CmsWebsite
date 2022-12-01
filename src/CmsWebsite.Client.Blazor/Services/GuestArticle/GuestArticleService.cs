using CmsWebsite.Share.Models.Article;
using CmsWebsite.Share.Models.GuestArticle;
using System.Net.Http.Json;

namespace CmsWebsite.Client.Blazor.Services.GuestArticle
{
    public class GuestArticleService : IGuestArticleService
    {
        private readonly HttpClient _httpClient;
        public GuestArticleService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Guid> CreateGuestArticle(GuestArticleCreateRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("api/GuestArticle/PostGuestArticle", request);
            Guid result = await response.Content.ReadFromJsonAsync<Guid>();
            return result;
        }

        public async Task<bool> DeleteGuestArticle(Guid id)
        {
            var result = await _httpClient.DeleteAsync($"api/GuestArticle/DeleteGuestArticle/{id}");
            return result.IsSuccessStatusCode;
        }

        public async Task<GuestArticleDTO> GetGuestArticle(Guid id)
        {
            var result = await _httpClient.GetFromJsonAsync<GuestArticleDTO>($"api/GuestArticle/GetGuestArticle/{id}");
            return result;
        }

        public async Task<List<GuestArticleDTO>> GetListGuestArticle()
        {
            var result = await _httpClient.GetFromJsonAsync<List<GuestArticleDTO>>("api/GuestArticle/GetGuestArticle");
            return result;
        }

        public async Task<GuestArticleUpdateRequest> GetUpdateGuestArticle(Guid id)
        {
            var result = await _httpClient.GetFromJsonAsync<GuestArticleUpdateRequest>($"api/GuestArticle/GetGuestArticle/{id}");
            return result;
        }

        public async Task<bool> UpdateGuestArticle(Guid id, GuestArticleUpdateRequest request)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/GuestArticle/PutArticle/{id}", request);
            return result.IsSuccessStatusCode;
        }
    }
}
