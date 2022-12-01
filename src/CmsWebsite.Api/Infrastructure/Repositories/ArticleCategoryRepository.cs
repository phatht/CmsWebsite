using CmsWebsite.Api.Domain.Interfaces;
using CmsWebsite.Api.Domain.Models;
using CmsWebsite.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CmsWebsite.Api.Infrastructure.Repositories
{
    public class ArticleCategoryRepository : BaseRepository, IArticleCategoryRepository
    {
        public ArticleCategoryRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ArticleCategories>> ListByCategoryIdAsync(Guid CategoryId)
        {
             
            return await _context.ArticleCategories.Where(i => i.CategoryID == CategoryId).AsNoTracking().IgnoreQueryFilters().ToListAsync();
        }

        public async Task<ArticleCategories> AddAsync(ArticleCategories ac)
        {
            await _context.ArticleCategories.AddAsync(ac);
            return ac;
        }

        public async Task<ArticleCategories> FindAsync(Guid id)
        {
            var ac = await _context.ArticleCategories
                .FirstOrDefaultAsync(r => r.ArticleID == id);
            return ac;
            //trả về category của article này
        }

        public void Update(ArticleCategories ac)
        {
            _context.ArticleCategories.Update(ac);
        }
    }
}
