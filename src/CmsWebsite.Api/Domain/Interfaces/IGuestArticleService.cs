using CmsWebsite.Api.Domain.Models;
using CmsWebsite.Share.Models.GuestArticle;

namespace CmsWebsite.Api.Domain.Interfaces
{
    public interface IGuestArticleService
    {
        Task<IEnumerable<GuestArticle>> GetGuestArticleAsync();

        Task<GuestArticle> GetGuestArticleAsync(Guid id);

        Task<Guid> PutGuestArticleAsync(GuestArticleCreateRequest request);

        Task<GuestArticle> DeleteGuestArticle(Guid id);

        Task<GuestArticle> PutGuestArticleAsync(Guid id, GuestArticleUpdateRequest request);
    }
}
