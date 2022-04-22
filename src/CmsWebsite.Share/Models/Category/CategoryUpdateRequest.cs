using CmsWebsite.Share.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CmsWebsite.Share.Models.Category
{
    public class CategoryUpdateRequest
    {
        [Required(ErrorMessage ="Bạn cần nhập loại bài viết")]
        public string CategoryName { get; set; }
        public long ParentCategoryId { get; set; }
        public string Abbreviation { get; set; }
        [Required(ErrorMessage ="Bạn cần thêm ảnh cho loại bài viết")]
        public string IconFile { get; set; }
    }
}
