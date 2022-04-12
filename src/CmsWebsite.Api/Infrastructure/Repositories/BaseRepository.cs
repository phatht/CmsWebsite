using CmsWebsite.Api.Infrastructure.Data;

namespace CmsWebsite.Api.Infrastructure.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
    }
}
