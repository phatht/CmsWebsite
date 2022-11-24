using CmsWebsite.Api.Domain.Models;
using CmsWebsite.Share.Models.GuestArticle;

namespace CmsWebsite.Api.Domain.Interfaces
{
    public interface IGuestArticleService
    {
        Task<IEnumerable<GuestArticle>> GetGuestArticleAsync();

        Task<GuestArticle> GetGuestArticleAsync(long id);

        Task<long> PutGuestArticleAsync(GuestArticleCreateRequest request);

        Task<GuestArticle> DeleteGuestArticle(long id);

        Task<GuestArticle> PutGuestArticleAsync(long id, GuestArticleUpdateRequest request);
    }
}
