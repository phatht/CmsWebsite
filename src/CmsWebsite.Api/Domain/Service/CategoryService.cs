using CmsWebsite.Api.Domain.Exceptions;
using CmsWebsite.Api.Domain.Interfaces;
using CmsWebsite.Api.Domain.Models;
using CmsWebsite.Share.Models.Category;

namespace CmsWebsite.Api.Domain.Service
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetCategoryAsync();

        Task<Category> GetCategoryAsync(Guid? id);
        //create
        Task<Category> PutCategoryAsync(CategoryCreateRequest request);

        Task<Category> DeleteCategory(Guid id);
        Task<Category> SoftDeleteCategory(Guid id, bool isDeleted);

        Task<Category> PutCategoryAsync(Guid id, CategoryUpdateRequest request);
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

        public async Task<Category> GetCategoryAsync(Guid? id)
        {
            return await _unitOfWork.CategoryRepository.FindAsync((Guid) id);
        }


        public async Task<Category> PutCategoryAsync(CategoryCreateRequest request)
        {
            try
            {
                var category = new Category()
                {
                    CategoryId = new Guid(),
                    CategoryName = request.CategoryName,
                    ParentCategoryId = request.ParentCategoryId,
                    Abbreviation = Guid.NewGuid().ToString(),
                    IconFile = request.IconFile,
                    //Level = (int)request.Level,
                };

                if (request.ParentCategoryId == null)
                {
                    category.Level = 1;
                }
                else
                {
                    var parent = await GetCategoryAsync(request.ParentCategoryId);
                    category.Level = parent.Level + 1;
                }


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

        public async Task<Category> PutCategoryAsync(Guid id, CategoryUpdateRequest request)
        {
            var existingCategory = await _unitOfWork.CategoryRepository.FindAsync(id);

            if (existingCategory is null)
            {
                throw new NotFoundException($"Article {id} is not found.");
            }

            existingCategory.CategoryName = request.CategoryName;
            existingCategory.IconFile = request.IconFile;

            if (request.ParentCategoryId == null)
            {
                existingCategory.Level = 1;
            }
            else
            {
                var parent = await GetCategoryAsync(request.ParentCategoryId);
                existingCategory.Level = parent.Level + 1;
            }

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

        public async Task<Category> DeleteCategory(Guid id)
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

        public async Task<Category> SoftDeleteCategory(Guid id, bool isDeleted)
        {
            var existingCategory = await _unitOfWork.CategoryRepository.FindAsync(id);

            if (existingCategory == null)
            {
                throw new NotFoundException($"Category {id} is not found.");
            }
            existingCategory.isDeleted = isDeleted;
            if (isDeleted)
            {
                existingCategory.DateDeleted = DateTime.Now;
            }
            else
            {
                existingCategory.DateDeleted = null;
            }
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
    }
}
