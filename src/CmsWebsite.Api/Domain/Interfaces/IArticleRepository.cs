using CmsWebsite.Api.Domain.Models;

namespace CmsWebsite.Api.Domain.Interfaces
{
    public interface IArticleRepository
    { 
        public Task<IEnumerable<Article>> ListAsync();

        public Task<Article> FindAsync(long id);

        public Task<Article> AddAsync(Article article);

        public void Update(Article reminder);

        public void Remove(Article reminder);

    }
}
