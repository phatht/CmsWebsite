using CmsWebsite.Share.Models.Category;

namespace CmsWebsite.Client.Blazor.Services.Category
{
    public interface ICategoryService
    {
        Task<List<CategoryDTO>> GetListCategory();
        Task<CategoryDTO> GetCategory(long id);
        Task<bool> CreateCategory(CategoryCreateRequest arRequest);
        Task<bool> UpdateCategory(long id, CategoryDTO arRequest);
        Task<bool> DeleteCategory(long id, bool isDeleted);
    }
}
