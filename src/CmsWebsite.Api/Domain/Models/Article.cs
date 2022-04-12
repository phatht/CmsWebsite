using System.Text.Json.Serialization;

namespace CmsWebsite.Api.Domain.Models
{
    public class Article
    {
        public long ArticleID { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string SummaryArticle { get; set; }
        public string ImageFile { get; set; }
        public DateTime PublishDate { get; set; }
        public int NumberOfViews { get; set; }
        public DateTime ExpireDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string KeyWords { get; set; }
        public string SubHead { get; set; }
        public int Status { get; set; }
        public bool taked { get; set; }
        public List<ArticleCategories> ArticleCategories { get; set; }
    }
}
