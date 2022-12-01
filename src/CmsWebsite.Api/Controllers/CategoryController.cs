#nullable disable
using CmsWebsite.Api.Domain.Models;
using CmsWebsite.Api.Domain.Service;
using CmsWebsite.Share.Models.Category;
using Microsoft.AspNetCore.Mvc;

namespace CmsWebsite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService ICategoryService)
        {
            _categoryService = ICategoryService;
        }

        //GET: api/Category
       [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            var category = await _categoryService.GetCategoryAsync();
            return Ok(category);
        }

        //GET: api/Category/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(Guid id)
        {
            var category = await _categoryService.GetCategoryAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // PUT: api/Category/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(Guid id, CategoryUpdateRequest request)
        {
            try
            {
                await _categoryService.PutCategoryAsync(id, request);
            }
            catch (Exception ex)
            {
                // Handle exception
                return StatusCode(500, $"A problem happened while handling your request {ex} .");
            }
            return NoContent();
        }

        // POST: api/Category
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(CategoryCreateRequest request)
        {
            var category = await _categoryService.PutCategoryAsync(request);

            return CreatedAtAction("GetCategory", new { id = category.CategoryId }, category);
        }

        // DELETE: api/Category/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Category>> DeleteCategory(Guid id)
        {
            var category = await _categoryService.GetCategoryAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            try
            {
                await _categoryService.DeleteCategory(id);
            }
            catch (Exception ex)
            {
                // Handle exception
                return StatusCode(500, "A problem happened while handling your request.");
            }
            return category;
        }
        [HttpDelete("soft/{id}")]
        public async Task<ActionResult<Category>> SoftDeleteCategory(Guid id, bool isDeleted)
        {
            try
            {
                await _categoryService.SoftDeleteCategory(id, isDeleted);
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
