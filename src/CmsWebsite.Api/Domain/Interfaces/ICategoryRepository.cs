using CmsWebsite.Api.Domain.Models;
using CmsWebsite.Share.Models.Category;

namespace CmsWebsite.Api.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        public Task<IEnumerable<Category>> ListAsync();

        public Task<Category> FindAsync(Guid id);

        public Task<Category> AddAsync(Category category);

        public void Update(Category category);

        public void Remove(Category category);
    }
}
