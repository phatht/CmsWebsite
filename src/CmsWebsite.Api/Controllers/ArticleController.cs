using CmsWebsite.Api.Domain.Models;
using CmsWebsite.Api.Domain.Service;
using CmsWebsite.Share.Models.Article;
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

        [HttpGet(nameof(SearchArticle))]
        public async Task<ActionResult<IEnumerable<Article>>> SearchArticle(string ws)
        {
            var articles = await _articleService.GetArticleAsync();
            var result = articles.Where(article => article.Title.ToLower().Trim().Contains(ws)).ToList();
            return result;
        }

        [HttpGet(nameof(LikeArticle))]
        public async Task<ActionResult> LikeArticle(Guid id, bool like)
        {
            await _articleService.PostLikeArticle(id, like);
            return Ok();
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
        public async Task<ActionResult<Article>> GetArticle(Guid id)
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
        public async Task<IActionResult> PutArticle(Guid id, ArticleUpdateRequest article)
        {
            if (id != article.ArticleID)
            {
                return BadRequest($"Not found {id}");
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
        public async Task<ActionResult<Guid>> PostArticle(ArticleCreateRequest article)
        {
            var result = await _articleService.PutArticleAsync(article);
            //return CreatedAtAction("GetArticle", new { id = result.ArticleID }, article);
            return result;
        }

        // DELETE: api/article/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Article>> DeleteArticle(Guid id)
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

        [HttpDelete("soft/{id}")]
        public async Task<IActionResult> SoftDeleteArticle(Guid id, bool isDeleted)
        {

            try
            {
                await _articleService.SoftDeleteArticle(id, isDeleted);
            }
            catch (Exception ex)
            {
                // Handle exception
                return StatusCode(500, "A problem happened while handling your request.");
            }
            return NoContent();
        }

        [HttpGet("GetArticleByCategoryId/{CategoryId}")]
        public async Task<ActionResult<IEnumerable<Article>>> GetArticleByCategoryIdAsync(Guid CategoryId)
        {
            var article = await _articleService.GetArticleByCategoryIdAsync(CategoryId);
            return Ok(article);
        }
    }
}
