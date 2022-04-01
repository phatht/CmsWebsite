using CmsWebsite.Api.Domain.Interfaces;
using CmsWebsite.Api.Infrastructure.Repositories;

namespace CmsWebsite.Api.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _context;

        public IArticleRepository _articleRepository;

        public IArticleRepository ArticleRepository
        {
            get
            {
                return _articleRepository = _articleRepository ?? new ArticleRepository(_context);
            }
        }

        public UnitOfWork(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task RollbackAsync()
        {
            await _context.DisposeAsync();
        }
    }
}
