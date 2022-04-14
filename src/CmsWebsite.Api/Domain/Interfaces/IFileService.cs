namespace CmsWebsite.Api.Domain.Interfaces
{
    public interface IFileService
    {
        Task<string> UploadFile(IFormFile image, string subDirectory);
        string SizeConverter(long bytes);
    }
}
