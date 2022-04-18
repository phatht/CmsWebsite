using CmsWebsite.Api.Domain.Models;

namespace CmsWebsite.Api.Domain.Interfaces
{
    public interface IArticleCategoryRepository
    {
        //public Task<IEnumerable<ArticleCategories>> ListAsync();

        public Task<ArticleCategories> FindAsync(long id);

        public Task<ArticleCategories> AddAsync(ArticleCategories ac);

        public void Update(ArticleCategories reminder);

        //public void Remove(ArticleCategories reminder);
    }
}
