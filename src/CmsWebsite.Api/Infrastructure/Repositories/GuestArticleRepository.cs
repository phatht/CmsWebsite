using CmsWebsite.Api.Domain.Interfaces;
using CmsWebsite.Api.Domain.Models;
using CmsWebsite.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CmsWebsite.Api.Infrastructure.Repositories
{
    public class GuestArticleRepository : BaseRepository, IGuestArticleRepository
    {
        public GuestArticleRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<GuestArticle>> ListAsync()
        {
            //IgnoreQueryFilter lấy tất cả dữ liệu kể cả phần bị lọc bỏ
            return await _context.GuestArticle.AsNoTracking().IgnoreQueryFilters().ToListAsync();
        }

        public async Task<GuestArticle> FindAsync(Guid id)
        {
            var guestArticle = await _context.GuestArticle.IgnoreQueryFilters()
                .FirstOrDefaultAsync(r => r.GuestArticleID == id);
            return guestArticle;
        }

        public async Task<GuestArticle> AddAsync(GuestArticle guestArticle)
        {
            await _context.GuestArticle.AddAsync(guestArticle);
            return guestArticle;
        }

        public void Update(GuestArticle guestArticle)
        {
            _context.GuestArticle.Update(guestArticle);
        }

        public void Remove(GuestArticle guestArticle)
        {
            _context.GuestArticle.Remove(guestArticle);
        }
    }
}
