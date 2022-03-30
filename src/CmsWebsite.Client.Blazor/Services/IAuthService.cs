using CmsWebsite.Share.Models.Authentication;

namespace CmsWebsite.Client.Blazor.Services
{
    public interface IAuthService
    {
        Task Login(LoginRequest loginRequest);
        Task Register(RegisterRequest registerRequest);
        Task Logout();
        Task<CurrentUser> CurrentUserInfo();
    }
}
