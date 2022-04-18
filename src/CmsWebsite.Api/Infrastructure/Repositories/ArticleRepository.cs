using CmsWebsite.Api.Domain.Interfaces;
using CmsWebsite.Api.Domain.Models;
using CmsWebsite.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CmsWebsite.Api.Infrastructure.Repositories
{
    public class ArticleRepository : BaseRepository, IArticleRepository
    {
        public ArticleRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Article>> ListAsync()
        {
            return await _context.Article.AsNoTracking().IgnoreQueryFilters().ToListAsync();
        }

        public async Task<Article> FindAsync(long id)
        {
            var article = await _context.Article.IgnoreQueryFilters()
                .FirstOrDefaultAsync(r => r.ArticleID == id);

            return article;
        }

        public async Task<Article> AddAsync(Article article)
        {
            await _context.Article.AddAsync(article);
            return article;
        }

        public void Update(Article article)
        {
            _context.Article.Update(article);
        }

        public void Remove(Article article)
        {
            _context.Article.Remove(article);
        }
    }
}
