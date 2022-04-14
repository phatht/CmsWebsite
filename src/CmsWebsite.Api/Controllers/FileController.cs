using CmsWebsite.Api.Domain.Interfaces;
using CmsWebsite.Share.Models.Article;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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
        public async Task<IActionResult> Upload([Required] IFormFile imageFile, string? subDirectory)
        {
            try
            {
                if (imageFile == null || imageFile.Length == 0) return BadRequest("Upload a file");

                var result = await _fileService.UploadFile(imageFile, subDirectory);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region Upload  
        [HttpDelete(nameof(Delete))]
        public async Task<ActionResult<bool>> Delete( string fileName, string? subDirectory)
        {
            try
            {
                if (fileName == null ) return BadRequest("Undefined a file name");

                var result = await _fileService.DeleteFile(fileName, subDirectory);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}