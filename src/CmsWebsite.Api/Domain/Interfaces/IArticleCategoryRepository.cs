using CmsWebsite.Api.Domain.Models;

namespace CmsWebsite.Api.Domain.Interfaces
{
    public interface IArticleCategoryRepository
    {
        public Task<IEnumerable<ArticleCategories>> ListByCategoryIdAsync(Guid CategoryId);

        public Task<ArticleCategories> FindAsync(Guid id);

        public Task<ArticleCategories> AddAsync(ArticleCategories ac);

        public void Update(ArticleCategories reminder);

        //public void Remove(ArticleCategories reminder);
    }
}
