using CmsWebsite.Share.Models.Category;
using CmsWebsite.Share.Response;

namespace CmsWebsite.Client.Blazor.Services.Category
{
    public interface ICategoryService
    {
        Task<List<CategoryDTO>> GetListCategory();
        Task<CategoryDTO> GetCategory(Guid id);
        Task<bool> CreateCategory(CategoryCreateRequest request);
        Task<bool> UpdateCategory(Guid id, CategoryUpdateRequest request);
        Task<bool> DeleteCategory(Guid id, bool isDeleted);
        Task<bool> DeleteCategoryImage(string fileName);
        Task<UploadFileResponse> UploadCategoryImage(MultipartFormDataContent content);
        Task<CategoryUpdateRequest> GetUpdateCategory(Guid id);

    }
}
