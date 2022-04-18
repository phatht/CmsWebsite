using CmsWebsite.Share.Models.Category;
using System.Net.Http.Json;

namespace CmsWebsite.Client.Blazor.Services.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;
        public CategoryService(HttpClient httClient)
        {
            _httpClient = httClient;
        }
        public async Task<bool> CreateCategory(CategoryCreateRequest caRequest)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/category", caRequest);
            return result.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteCategory(long id, bool isDeleted)
        {
            var result = await _httpClient.DeleteAsync($"api/category/soft/{id}?isDeleted={isDeleted}");
            return result.IsSuccessStatusCode;
        }

        public async Task<CategoryDTO> GetCategory(long id)
        {
            var result = await _httpClient.GetFromJsonAsync<CategoryDTO>($"api/category/{id}");
            return result;
        }

        public async Task<List<CategoryDTO>> GetListCategory()
        {
            var result = await _httpClient.GetFromJsonAsync<List<CategoryDTO>>("api/category");
            return result;
        }

        public async Task<bool> UpdateCategory(long id, CategoryDTO caRequest)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/category/{id}", caRequest);
            return result.IsSuccessStatusCode;
        }
    }
}
