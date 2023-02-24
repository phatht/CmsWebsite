﻿using CmsWebsite.Share.Response;

namespace CmsWebsite.Api.Domain.Interfaces
{
    public interface IFileService
    {
        Task<UploadFileResponse> UploadFile(IFormFile file, string? subDirectory);
        Task<bool> DeleteFile(string fileName);

        string SizeConverter(long bytes);
    }
}