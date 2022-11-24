using CmsWebsite.Share.Models.Article;
using CmsWebsite.Share.Models.GuestArticle;

namespace CmsWebsite.Client.Blazor.Services.GuestArticle
{
    public interface IGuestArticleService
    {
        Task<List<GuestArticleDTO>> GetListGuestArticle();
        Task<GuestArticleDTO> GetGuestArticle(long id);
        Task<long> CreateGuestArticle(GuestArticleCreateRequest request);
        Task<GuestArticleUpdateRequest> GetUpdateGuestArticle(long id);
        Task<bool> UpdateGuestArticle(long id, GuestArticleUpdateRequest request);
        Task<bool> DeleteGuestArticle(long id);
    }
}
