using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsWebsite.Share.Models.GuestArticle
{
    public class GuestArticleCreateRequest
    {
        [Required(ErrorMessage = "Bạn cần nhập họ và tên.")]
        public string FullName { get; set; }
        [MaxLength(10, ErrorMessage = "Số điện thoại chỉ tối đa 10 số.")]
        [Required(ErrorMessage = "Bạn cần nhập số điện thoại.")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Bạn cần nhập email.")]
        [EmailAddress(ErrorMessage = "Email không phù hợp")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Bạn cần nhập địa chỉ.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Bạn cần nhập tiêu đề bài viết.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Bạn cần nhập mô tả bài viết.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Bạn cần nhập chi tiết bài viết.")]
        public string SummaryArticle { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
