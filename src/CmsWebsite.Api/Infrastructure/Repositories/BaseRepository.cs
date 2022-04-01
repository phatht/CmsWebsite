using CmsWebsite.Api.Infrastructure.Data;

namespace CmsWebsite.Api.Infrastructure.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly ApplicationDBContext _context;

        public BaseRepository(ApplicationDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
    }
}
