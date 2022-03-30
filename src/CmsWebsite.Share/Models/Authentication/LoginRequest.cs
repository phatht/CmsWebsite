
using System.ComponentModel.DataAnnotations;

namespace CmsWebsite.Share.Models.Authentication
{
    public class LoginRequest
    {
        [Required(ErrorMessage ="Thông tin bắt buộc nhập")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Thông tin bắt buộc nhập")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
