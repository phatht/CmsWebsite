using CmsWebsite.Api.Domain.Interfaces;
using CmsWebsite.Share.Response;

namespace CmsWebsite.Api.Domain.Service
{
    public class FileService : IFileService
    {
        #region Property  
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;
        #endregion

        #region Constructor  
        public FileService(IWebHostEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
        }
        #endregion

        #region Upload File  
        public async Task<UploadFileResponse> UploadFile(IFormFile image, string? subDirectory)
        {
            subDirectory = subDirectory ?? string.Empty;

            var check = CheckFileType(image.FileName);
            if (!check) throw new Exception($"File is not a valid image");

            string uniqueFileName = $"upload-{DateTime.Today.ToString("yyyy-MM-dd")}-{Guid.NewGuid()}{Path.GetExtension(image.FileName)}";

            //đường dẫn config từ appsetting của api application
            string _configPath = _configuration["UploadPath"];

            //đường dẫn upload mặc định theo năm tháng 
            string uploadPath = "uploads" + @"\" + DateTime.Now.Year + @"\" + DateTime.Now.Month;

            //đường dẫn đến subfolder
            string uploadsFolder = Path.Combine(_configPath, uploadPath, subDirectory);

            //kiểm tra tồn tại và tạo thư mục nếu chưa có
            if (!File.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            //đường dẫn hoàn chỉnh đến tên file
            var fullPath = Path.Combine(uploadsFolder, uniqueFileName);

            //xử lí load ảnh
            var response = new UploadFileResponse();
            //đường dẫn load ảnh
            response.loadPathFolder = _configuration["UploadPath"];
            response.loadPathFile = Path.Combine(uploadPath, subDirectory, uniqueFileName);

            using (var fileStream = new FileStream(fullPath, FileMode.Create, FileAccess.Write))
            {
                await image.CopyToAsync(fileStream);
            }
            return response;
        }
        #endregion

        #region Upload File  
        public async Task<bool> DeleteFile(string loadPath)
        {

            string _configPath = _configuration["UploadPath"];

            var fullPath = Path.Combine(_configPath, loadPath);

            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
                return true;
            }
            throw new Exception($"Can't find the file or folder is not exist: {loadPath}");
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
