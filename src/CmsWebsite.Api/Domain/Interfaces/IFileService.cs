namespace CmsWebsite.Api.Domain.Interfaces
{
    public interface IFileService
    {
        Task<string> UploadFile(IFormFile image, string? subDirectory);
        Task<bool> DeleteFile(string fileName, string? subDirectory);

        string SizeConverter(long bytes);
    }
}
