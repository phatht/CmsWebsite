﻿using CmsWebsite.Api.Domain.Interfaces;

namespace CmsWebsite.Api.Domain.Service
{
    public class FileService : IFileService
    {
        #region Property  
        private IWebHostEnvironment _hostingEnvironment;
        #endregion

        #region Constructor  
        public FileService(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        #endregion

        #region Upload File  
        public async Task<string> UploadFile(IFormFile image, string? subDirectory)
        {
            subDirectory = subDirectory ?? string.Empty;
            var check = CheckFileType(image.FileName);
            if (!check) throw new Exception($"File is not a valid image");

            string uniqueFileName = $"upload-{DateTime.Today.ToString("yyyy-MM-dd")}-{Guid.NewGuid()}{Path.GetExtension(image.FileName)}";

            string _configPath = @"D:\TranPhat\Projects\CmsWebsite\src\CmsWebsite.Client.Blazor\";
            //string path = "uploads" + @"\" + DateTime.Now.Year + @"\" + DateTime.Now.Month;

            string uploadsFolder = Path.Combine(_configPath, "wwwroot", "uploads", subDirectory);

            if (!File.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                await image.CopyToAsync(fileStream);
            }
            return uniqueFileName;
        }
        #endregion

        #region Upload File  
        public async Task<bool> DeleteFile(string fileName, string? subDirectory)
        {
            subDirectory = subDirectory ?? string.Empty;

            string _configPath = @"D:\TranPhat\Projects\CmsWebsite\src\CmsWebsite.Client.Blazor\";

            string existingFolder = Path.Combine(_configPath, "wwwroot", "uploads", subDirectory);
            var fullPath = Path.Combine(existingFolder, fileName);

            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
                return true;
            }
            throw new Exception($"Can't find the file :{fileName} or folder is not exist: {existingFolder}");
        }
        #endregion

        #region Size Converter  
        public string SizeConverter(long bytes)
        {
            var fileSize = new decimal(bytes);
            var kilobyte = new decimal(1024);
            var megabyte = new decimal(1024 * 1024);
            var gigabyte = new decimal(1024 * 1024 * 1024);

            switch (fileSize)
            {
                case var _ when fileSize < kilobyte:
                    return $"Less then 1KB";
                case var _ when fileSize < megabyte:
                    return $"{Math.Round(fileSize / kilobyte, 0, MidpointRounding.AwayFromZero):##,###.##}KB";
                case var _ when fileSize < gigabyte:
                    return $"{Math.Round(fileSize / megabyte, 2, MidpointRounding.AwayFromZero):##,###.##}MB";
                case var _ when fileSize >= gigabyte:
                    return $"{Math.Round(fileSize / gigabyte, 2, MidpointRounding.AwayFromZero):##,###.##}GB";
                default:
                    return "n/a";
            }
        }
        #endregion

        bool CheckFileType(string fileName)
        {

            string ext = Path.GetExtension(fileName);
            switch (ext.ToLower())
            {
                case ".gif":
                    return true;
                case ".png":
                    return true;
                case ".jpg":
                    return true;
                case ".jpeg":
                    return true;
                default:
                    return false;
            }
        }

    }
}