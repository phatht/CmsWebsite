namespace CmsWebsite.Share.Models.Article
{
    public class CreateArticleRequest
    {
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string SummaryArticle { get; set; }
        public string ImageFile { get; set; }
        public DateTime PublishDate { get; set; }
        public string KeyWords { get; set; }
        public string SubHead { get; set; }
    }
}
