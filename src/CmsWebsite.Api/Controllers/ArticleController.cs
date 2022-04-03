using CmsWebsite.Api.Domain.Models;
using CmsWebsite.Api.Domain.Service;
using Microsoft.AspNetCore.Mvc;

namespace CmsWebsite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService IArticleService)
        {
            _articleService = IArticleService;
        }

        // GET: api/article
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Article>>> GetArticle()
        {
            var article = await _articleService.GetArticleAsync();
           return Ok(article);
        }

        // GET: api/article/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Article>> GetArticle(long id)
        {
            var article = await _articleService.GetArticleAsync(id);
            if (article == null)
            {
                return NotFound();
            }
            return article;
        }

        // PUT: api/article/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticle(long id, Article article)
        {
            if (id != article.ArticleID)
            {
                return BadRequest();
            }
            try
            {
                await _articleService.PutArticleAsync(id, article);
            }
            catch (Exception ex)
            {
                // Handle exception
                return StatusCode(500, "A problem happened while handling your request.");
            }
            return NoContent();
        }

        // POST: api/article
        [HttpPost]
        public async Task<ActionResult<Article>> PostArticle(Article article)
        {
            await _articleService.PutArticleAsync(article);
            return CreatedAtAction("GetArticle", new { id = article.ArticleID }, article);
        }

        // DELETE: api/article/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Article>> DeleteArticle(long id)
        {
            var article = await _articleService.GetArticleAsync(id);
            if (article == null)
            {
                return NotFound();
            }
            try
            {
                await _articleService.DeleteArticle(id);
            }
            catch (Exception ex)
            {
                // Handle exception
                return StatusCode(500, "A problem happened while handling your request.");
            }
            return article;
        }
    }
}
