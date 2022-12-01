using CmsWebsite.Api.Domain.Models;
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
        public async Task<IActionResult> PostArticleCategory(ArticleCategoryRequest request)
        {
            var result = await _articleCategoryService.PutArticleCategory(request);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ArticleCategories>> GetArticleCategory(Guid id)
        {
            var ac = await _articleCategoryService.GetArticleCategory(id);
            if (ac == null)
            {
                return NotFound();
            }
            return ac;
        }
        [HttpPut("{articleId}")]
        public async Task<ActionResult<ArticleCategories>> PutArticleCategory(Guid articleId, ArticleCategories ac)
        {
            try
            {
                await _articleCategoryService.PutArticleCategory(articleId, ac);
            }
            catch (Exception ex)
            {
                // Handle exception
                return StatusCode(500, "A problem happened while handling your request.");
            }
            return NoContent();
        }
    }
}
