using System.ComponentModel.DataAnnotations;

namespace CmsWebsite.Share.Models.Article
{
    public class ArticleUpdateRequest
    {
        public long ArticleID { get; set; }
        [Required(ErrorMessage = "Bạn cần nhập tiêu đề.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Bạn cần nhập mô tả bài viết.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Bạn cần nhập nội dung bài viết.")]
        public string SummaryArticle { get; set; }
        [Required(ErrorMessage = "Bạn cần chọn ảnh đại diện bài viết.")]
        public string ImageFile { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime? ExpireDate { get; set; }
        public string KeyWords { get; set; }
        public string SubHead { get; set; }
        public string Author { get; set; }
        public string? Video { get; set; }
    }
}
