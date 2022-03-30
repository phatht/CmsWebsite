using System.ComponentModel.DataAnnotations;

namespace CmsWebsite.Share.Models.Authentication
{
    public class RegisterRequest
    {
        [Required(ErrorMessage = "Thông tin bắt buộc nhập")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Thông tin bắt buộc nhập")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Thông tin bắt buộc nhập")]
        [Compare(nameof(Password), ErrorMessage = "Mật khẩu không phù hợp!")]
        public string PasswordConfirm { get; set; }
    }
}
