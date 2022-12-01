using CmsWebsite.Api.Domain.Interfaces;
using CmsWebsite.Api.Domain.Models;
using CmsWebsite.Api.Infrastructure.Data;
using CmsWebsite.Share.Models.Category;
using Microsoft.EntityFrameworkCore;

namespace CmsWebsite.Api.Infrastructure.Repositories
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Category>> ListAsync()
        {
            //IgnoreQueryFilter lấy tất cả dữ liệu kể cả phần bị lọc bỏ
            return await _context.Categories.AsNoTracking().IgnoreQueryFilters().ToListAsync();
        }

        public async Task<Category> AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            return category;
        }

        public async Task<Category> FindAsync(Guid id)
        {
            var category = await _context.Categories.IgnoreQueryFilters()
                .FirstOrDefaultAsync(r => r.CategoryId == id);
            return category;
        }

        public async void Update(Category category)
        {
            _context.Categories.Update(category);
        }

        public void Remove(Category category)
        {
            _context.Categories.Remove(category);
        }
    }
}
