using System.ComponentModel.DataAnnotations;

namespace CmsWebsite.Share.Models.ArticleCategory
{
    public class ArticleCategoryRequest
    {
        public Guid ArticleID { get; set; }
        public Guid CategoryID { get; set; }
    }
}
