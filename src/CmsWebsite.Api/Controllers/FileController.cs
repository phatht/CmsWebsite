using CmsWebsite.Api.Domain.Interfaces;
using CmsWebsite.Share.Models.Article;
using Microsoft.AspNetCore.Mvc;

namespace CmsWebsite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // Must be in the Administrator Role
    public class FileController : Controller
    {
        #region Property  
        private readonly IFileService _fileService;
        #endregion

        #region Constructor  
        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }
        #endregion

        #region Upload  
        [HttpPost(nameof(Upload))]
        public async Task<IActionResult> Upload([FromForm] UploadArticleImageRequest request)
        {
            try
            {
                if (request.imageFile == null || request.imageFile.Length == 0) return BadRequest("Upload a file");

                var result = await _fileService.UploadFile(request.imageFile, request.subDirectory);

                return Ok(new { uniqueFileName = result, size = _fileService.SizeConverter(request.imageFile.Length) });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}