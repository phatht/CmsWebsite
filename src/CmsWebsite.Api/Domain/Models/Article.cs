using System.ComponentModel.DataAnnotations;

namespace CmsWebsite.Api.Domain.Models
{
    public class Article 
    {
        [Key]
        public Guid ArticleID { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string SummaryArticle { get; set; }
        public string ImageFile { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime? ExpireDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string KeyWords { get; set; }
        public string SubHead { get; set; }
        public int Status { get; set; }
        public int NumberOfViews { get; set; }
        public bool isDeleted { get; set; }
        public DateTime? DateDeleted { get; set; }
        public string Author { get; set; }
        public int Like { get; set; }
        public string? Video { get; set; }
        public int View { get; set; }
    }
}
