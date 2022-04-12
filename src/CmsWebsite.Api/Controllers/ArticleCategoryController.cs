using CmsWebsite.Api.Domain.Service;
using CmsWebsite.Share.Models.ArticleCategory;
using Microsoft.AspNetCore.Mvc;

namespace CmsWebsite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleCategoryController : ControllerBase
    {
        private readonly IArticleCategoryService _articleCategoryService;
        public ArticleCategoryController(IArticleCategoryService ArticleCategoryService)
        {
            _articleCategoryService = ArticleCategoryService;
        }
        [HttpPost]
        public async Task<IActionResult> PostArticleCategory(ArticleCategoryCreateRequest request)
        {
            var result = await _articleCategoryService.PutArticleAsync(request);
            return Ok(result);
        }
    }
}
