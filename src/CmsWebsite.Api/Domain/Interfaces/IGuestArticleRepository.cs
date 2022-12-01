using CmsWebsite.Api.Domain.Models;

namespace CmsWebsite.Api.Domain.Interfaces
{
    public interface IGuestArticleRepository
    {
        public Task<IEnumerable<GuestArticle>> ListAsync();

        public Task<GuestArticle> FindAsync(Guid id);

        public Task<GuestArticle> AddAsync(GuestArticle guestArticle);

        public void Update(GuestArticle reminder);

        public void Remove(GuestArticle reminder);
    }
}
