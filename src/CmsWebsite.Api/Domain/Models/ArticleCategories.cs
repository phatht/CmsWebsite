namespace CmsWebsite.Api.Domain.Models
{
    public class ArticleCategories
    {
        public long ArticleID { get; set; }
        public Article Article { get; set; }
        public long CategoryID { get; set; }
        public Category Category { get; set; }


    }
}
