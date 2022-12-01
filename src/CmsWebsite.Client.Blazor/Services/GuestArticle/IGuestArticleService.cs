using CmsWebsite.Share.Models.Article;
using CmsWebsite.Share.Models.GuestArticle;

namespace CmsWebsite.Client.Blazor.Services.GuestArticle
{
    public interface IGuestArticleService
    {
        Task<List<GuestArticleDTO>> GetListGuestArticle();
        Task<GuestArticleDTO> GetGuestArticle(Guid id);
        Task<Guid> CreateGuestArticle(GuestArticleCreateRequest request);
        Task<GuestArticleUpdateRequest> GetUpdateGuestArticle(Guid id);
        Task<bool> UpdateGuestArticle(Guid id, GuestArticleUpdateRequest request);
        Task<bool> DeleteGuestArticle(Guid id);
    }
}
