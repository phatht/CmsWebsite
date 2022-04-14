using CmsWebsite.Share.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CmsWebsite.Share.Models.Category
{
    public class CategoryUpdateRequest
    {
        [Required]
        public string CategoryName { get; set; }
        public long ParentCategoryId { get; set; }
        [Required]
        public string Abbreviation { get; set; }
        [Required]
        public IFormFile IconFile { get; set; }
        [Required]
        public Level Level { get; set; }
    }
}
