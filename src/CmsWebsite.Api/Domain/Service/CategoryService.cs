using CmsWebsite.Api.Domain.Exceptions;
using CmsWebsite.Api.Domain.Interfaces;
using CmsWebsite.Api.Domain.Models;
using CmsWebsite.Share.Models.Category;

namespace CmsWebsite.Api.Domain.Service
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetCategoryAsync();

        Task<Category> GetCategoryAsync(long id);
        //create
        Task<Category> PutCategoryAsync(CategoryCreateRequest request);

        Task<Category> DeleteCategory(long id);

        Task<Category> PutCategoryAsync(long id, CategoryDTO category);
    }
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CategoryService> _logger;

        public CategoryService(IUnitOfWork unitOfWork, ILogger<CategoryService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }



        public async Task<IEnumerable<Category>> GetCategoryAsync()
        {
            return await _unitOfWork.CategoryRepository.ListAsync();
        }

        public async Task<Category> GetCategoryAsync(long id)
        {
            return await _unitOfWork.CategoryRepository.FindAsync(id);
        }


        public async Task<Category> PutCategoryAsync(CategoryCreateRequest request)
        {
            try
            {
                var category = new Category()
                {
                    CategoryName = request.CategoryName,
                    ParentCategoryId = request.ParentCategoryId,
                    Abbreviation = request.Abbreviation,
                    IconFile = request.IconFile,
                    Level = (int)request.Level,
                };
                var result = await _unitOfWork.CategoryRepository.AddAsync(category);
                await _unitOfWork.CommitAsync();

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error when create article {ex}", ex.Message);
                throw;
            }
        }

        public async Task<Category> PutCategoryAsync(long id, CategoryDTO category)
        {
            var existingCategory = await _unitOfWork.CategoryRepository.FindAsync(id);

            if (existingCategory is null)
            {
                throw new NotFoundException($"Article {id} is not found.");
            }

            existingCategory.ParentCategoryId = category.ParentCategoryId;
            existingCategory.CategoryName = category.CategoryName;
            existingCategory.Abbreviation = category.Abbreviation;
            existingCategory.IconFile = category.IconFile;
            existingCategory.Level = category.Level;

            try
            {
                _unitOfWork.CategoryRepository.Update(existingCategory);
                await _unitOfWork.CommitAsync();

                return existingCategory;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error when update category {ex}", ex.Message);
                throw ex;
            }
        }

        public async Task<Category> DeleteCategory(long id)
        {
            var existingCategory = await _unitOfWork.CategoryRepository.FindAsync(id);

            if (existingCategory is null)
            {
                throw new NotFoundException($"Article {id} is not found.");
            }

            try
            {
                _unitOfWork.CategoryRepository.Remove(existingCategory);
                await _unitOfWork.CommitAsync();

                return existingCategory;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error when delete category {ex}", ex.Message);
                throw ex;
            }
        }
    }
}
