using System.ComponentModel.DataAnnotations;

namespace CmsWebsite.Share.Models.Article
{
    public class ArticleCreateRequest
    {
        //public long ArticleID { get; set; }

        //khi form submit dữ liệu từ form sẽ đi qua các validator để kiểm tra dữ liệu
        public string UserId { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập tiêu đề.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập mô tả bài viết.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập nội dung bài viết.")]
        public string SummaryArticle { get; set; }

        [Required(ErrorMessage = "Bạn cần chọn ảnh đại diện bài viết.")]
        public string ImageFile { get; set; }

        public string Author { get; set; }

        public DateTime PublishDate { get; set; }

        public string? KeyWords { get; set; }

        public string? SubHead { get; set; }


    }

}
