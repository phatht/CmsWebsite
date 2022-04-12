using CmsWebsite.Api.Domain.Interfaces;
using CmsWebsite.Api.Domain.Models;
using CmsWebsite.Api.Infrastructure.Data;

namespace CmsWebsite.Api.Infrastructure.Repositories
{
    public class ArticleCategoryRepository : BaseRepository, IArticleCategoryRepository
    {
        public ArticleCategoryRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<ArticleCategories> AddAsync(ArticleCategories ac)
        {
            await _context.ArticleCategories.AddAsync(ac);
            return ac;
        }
    }
}
