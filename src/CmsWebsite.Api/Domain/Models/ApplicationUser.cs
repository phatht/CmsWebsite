using Microsoft.AspNetCore.Identity;
namespace CmsWebsite.Api.Domain.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
