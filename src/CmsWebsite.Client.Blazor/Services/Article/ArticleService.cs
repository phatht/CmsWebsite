using CmsWebsite.Share.Models.Article;
using CmsWebsite.Share.Response;
using Newtonsoft.Json;
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

        public async Task<long> CreateArticle(ArticleCreateRequest arRequest)
        {
            var response = await _httpClient.PostAsJsonAsync("api/article", arRequest);
            long result = await response.Content.ReadFromJsonAsync<long>();
            return result;
        }

        public async Task<bool> DeleteArticle(long id, bool isDeleted)
        {
            var result = await _httpClient.DeleteAsync($"/api/article/soft/{id}?isDeleted={isDeleted}");
            return result.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteArticleFile(string fileName)
        {
            var result = await _httpClient.DeleteAsync($"api/file/delete?fileName={fileName}");
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

        public async Task<bool> UpdateArticle(long id, ArticleUpdateRequest request)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/article/{id}", request);
            return result.IsSuccessStatusCode;
        }

        public async Task<UploadFileResponse> UploadArticleFile(MultipartFormDataContent content)
        {
            var response = await _httpClient.PostAsync($"api/file/upload?subDirectory=articles", content);
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Check Upload Article Image, {await response.Content.ReadAsStringAsync()}");
            }
            else
            {

               return await response.Content.ReadFromJsonAsync<UploadFileResponse>();
            }
        }
        public async Task<List<ArticleDTO>> GetListArticleCategoryByCategoryId(long categoryId)
        {
            var result = await _httpClient.GetFromJsonAsync<List<ArticleDTO>>($"api/article/GetArticleByCategoryId/{categoryId}");
            return result;
        }

        public async Task<ArticleUpdateRequest> GetUpdateArticle(long id)
        {
            var result = await _httpClient.GetFromJsonAsync<ArticleUpdateRequest>($"api/article/{id}");
            return result;
        }

        public async Task LikeArticle(long id, bool like)
        {
            await _httpClient.GetAsync($"api/Article/LikeArticle?id={id}&like={like}");
        }

        public async Task<List<ArticleDTO>> GetArticlesFromSearch(string ws)
        {
            var result = await _httpClient.GetFromJsonAsync<List<ArticleDTO>>($"api/Article/SearchArticle/{ws}");
            return result;
        }
    }
}
