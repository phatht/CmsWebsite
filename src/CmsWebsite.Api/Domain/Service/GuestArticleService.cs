using CmsWebsite.Api.Domain.Interfaces;
using CmsWebsite.Api.Domain.Models;
using CmsWebsite.Share.Models.GuestArticle;

namespace CmsWebsite.Api.Domain.Service
{
    public class GuestArticleService : IGuestArticle
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GuestArticleService> _logger;

        public GuestArticleService(IUnitOfWork unitOfWork, ILogger<GuestArticleService> logger)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public Task<GuestArticle> DeleteGuestArticle(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GuestArticle>> GetGuestArticleAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GuestArticle> GetGuestArticleAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<long> PutGuestArticleAsync(GuestArticleCreateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<GuestArticle> PutGuestArticleAsync(long id, GuestArticleUpdateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
