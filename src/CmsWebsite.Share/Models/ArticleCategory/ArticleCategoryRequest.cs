using System.ComponentModel.DataAnnotations;

namespace CmsWebsite.Share.Models.ArticleCategory
{
    public class ArticleCategoryRequest
    {
        public long ArticleID { get; set; }
        public long CategoryID { get; set; }
    }
}
