using CmsWebsite.Api.Domain.Interfaces;
using CmsWebsite.Api.Domain.Models;
using CmsWebsite.Share.Models.GuestArticle;
using Microsoft.AspNetCore.Mvc;

namespace CmsWebsite.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GuestArticleController : ControllerBase
    {
        private readonly IGuestArticleService _guestArticleService;

        public GuestArticleController(IGuestArticleService guestArticleService)
        {
            _guestArticleService = guestArticleService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GuestArticle>>> GetGuestArticle()
        {
            var guestArticle = await _guestArticleService.GetGuestArticleAsync();
            return Ok(guestArticle);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GuestArticle>> GetGuestArticle(Guid id)
        {
            var guestArticle = await _guestArticleService.GetGuestArticleAsync(id);
            if (guestArticle == null)
            {
                return NotFound();
            }
            return guestArticle;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticle(Guid id, GuestArticleUpdateRequest guestArticle)
        {
            if (id != guestArticle.GuestArticleID)
            {
                return BadRequest($"Not found {id}");
            }
            try
            {
                await _guestArticleService.PutGuestArticleAsync(id, guestArticle);
            }
            catch (Exception ex)
            {
                // Handle exception
                return StatusCode(500, "A problem happened while handling your request.");
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> PostGuestArticle(GuestArticleCreateRequest guestArticle)
        {
            var result = await _guestArticleService.PutGuestArticleAsync(guestArticle);
            return result;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<GuestArticle>> DeleteGuestArticle(Guid id)
        {
            var guestArticle = await _guestArticleService.GetGuestArticleAsync(id);
            if (guestArticle == null)
            {
                return NotFound();
            }
            try
            {
                await _guestArticleService.DeleteGuestArticle(id);
            }
            catch (Exception ex)
            {
                // Handle exception
                return StatusCode(500, "A problem happened while handling your request.");
            }
            return guestArticle;
        }
    }
}
