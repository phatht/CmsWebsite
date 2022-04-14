using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CmsWebsite.Share.Models.Article
{
    public class UploadArticleImageRequest
    {
        [Required]
        public IFormFile imageFile { get; set; }
        public string? subDirectory { get; set; }
    }
}
