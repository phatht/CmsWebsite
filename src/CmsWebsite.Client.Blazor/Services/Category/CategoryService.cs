using CmsWebsite.Share.Models.Category;
using CmsWebsite.Share.Response;
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

        public async Task<bool> UpdateCategory(long id, CategoryUpdateRequest request)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/category/{id}", request);
            return result.IsSuccessStatusCode;
        }

        public async Task<UploadFileResponse> UploadCategoryImage(MultipartFormDataContent content)
        {
            var response = await _httpClient.PostAsync($"api/file/upload?subDirectory=categories", content);
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Check Upload Category Image, {await response.Content.ReadAsStringAsync()}");
            }
            else
            {
                return await response.Content.ReadFromJsonAsync<UploadFileResponse>();
            }
        }

        public async Task<bool> DeleteCategoryImage(string fileName)
        {
            var result = await _httpClient.DeleteAsync($"api/file/delete?fileName={fileName}");
            return result.IsSuccessStatusCode;
        }

        public async Task<CategoryUpdateRequest> GetUpdateCategory(long id)
        {
            var result = await _httpClient.GetFromJsonAsync<CategoryUpdateRequest>($"api/category/{id}");
            return result;
        }
    }
}
