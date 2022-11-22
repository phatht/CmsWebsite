using Microsoft.AspNetCore.Http;

namespace CmsWebsite.Client.Blazor.Services.File
{
    public class FileService : IFileService
    {
        private readonly HttpClient _httpClient;
        public FileService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<string> UploadImageEditor()
        {
            var result = await _httpClient.GetStringAsync($"api/file/UploadImageEditor");
            return result;
        }
    }
}
