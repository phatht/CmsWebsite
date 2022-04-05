namespace CmsWebsite.Share.Models.Article
{
    public class ArListDTO
    {
        public long ArticleID { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string SummaryArticle { get; set; }
        public string ImageFile { get; set; }
        public DateTime PublishDate { get; set; }
        public int NumberOfViews { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int Status { get; set; }
    }


}
