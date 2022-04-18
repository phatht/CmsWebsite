using CmsWebsite.Share.Enums;
using System.ComponentModel.DataAnnotations;

namespace CmsWebsite.Share.Models.Category
{
    public class CategoryCreateRequest
    {
        [Required]
        public string CategoryName { get; set; }
        public long ParentCategoryId { get; set; }
        [Required]
        public string IconFile { get; set; }
        [Required]
        public Level Level { get; set; }
    }
}
