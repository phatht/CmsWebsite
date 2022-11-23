using CmsWebsite.Api.Domain.Exceptions;
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

        public async Task<GuestArticle> DeleteGuestArticle(long id)
        {
            var guestArticle = await _unitOfWork.GuestArticleRepository.FindAsync(id);

            if (guestArticle == null)
            {
                throw new NotFoundException($"Article {id} is not found.");
            }

            try
            {
                _unitOfWork.GuestArticleRepository.Remove(guestArticle);
                await _unitOfWork.CommitAsync();

                return guestArticle;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error when delete article {ex}", ex.Message);
                throw ex;
            }
        }

        public async Task<IEnumerable<GuestArticle>> GetGuestArticleAsync()
        {
            return await _unitOfWork.GuestArticleRepository.ListAsync();
        }

        public async Task<GuestArticle> GetGuestArticleAsync(long id)
        {
            return await _unitOfWork.GuestArticleRepository.FindAsync(id);
        }

        public async Task<long> PutGuestArticleAsync(GuestArticleCreateRequest request)
        {
            try
            {
                var guestArticle = new GuestArticle()
                {
                    FullName = request.FullName,
                    Phone = request.Phone,
                    Address = request.Address,
                    Title = request.Title,
                    Description = request.Description,
                    SummaryArticle = request.SummaryArticle,
                    CreatedDate = DateTime.Now
                };

                var result = await _unitOfWork.GuestArticleRepository.AddAsync(guestArticle);
                await _unitOfWork.CommitAsync();

                return result.GuestArticleID;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error when create article {ex}", ex.Message);
                throw;
            }
        }

        public async Task<GuestArticle> PutGuestArticleAsync(long id, GuestArticleUpdateRequest request)
        {
            var guestArticle = await GetGuestArticleAsync(id);

            if (guestArticle == null)
            {
                throw new NotFoundException($"Article {id} is not found.");
            }
            guestArticle.FullName = request.FullName;
            guestArticle.Phone = request.Phone;
            guestArticle.Address = request.Address;
            guestArticle.Title = request.Title;
            guestArticle.Description = request.Description;
            guestArticle.SummaryArticle = request.SummaryArticle;
            try
            {
                _unitOfWork.GuestArticleRepository.Update(guestArticle);
                await _unitOfWork.CommitAsync();

                return guestArticle;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error when update article {ex}", ex.Message);
                throw ex;
            }
        }
    }
}
