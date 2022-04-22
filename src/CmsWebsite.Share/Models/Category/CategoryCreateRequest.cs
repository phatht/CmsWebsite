using CmsWebsite.Share.Enums;
using System.ComponentModel.DataAnnotations;

namespace CmsWebsite.Share.Models.Category
{
    public class CategoryCreateRequest
    {
        [Required(ErrorMessage = "Bạn cần nhập tên loại bài viết.")]
        public string CategoryName { get; set; }
        public long ParentCategoryId { get; set; }
        [Required(ErrorMessage = "Bạn cần thêm ảnh cho loại bài viết.")]
        public string IconFile { get; set; }
    }
}
