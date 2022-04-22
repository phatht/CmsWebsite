using CmsWebsite.Share.Models.Category;
using CmsWebsite.Share.Response;

namespace CmsWebsite.Client.Blazor.Services.Category
{
    public interface ICategoryService
    {
        Task<List<CategoryDTO>> GetListCategory();
        Task<CategoryDTO> GetCategory(long id);
        Task<bool> CreateCategory(CategoryCreateRequest request);
        Task<bool> UpdateCategory(long id, CategoryUpdateRequest request);
        Task<bool> DeleteCategory(long id, bool isDeleted);
        Task<bool> DeleteCategoryImage(string fileName);
        Task<UploadFileResponse> UploadCategoryImage(MultipartFormDataContent content);
        Task<CategoryUpdateRequest> GetUpdateCategory(long id);

    }
}
