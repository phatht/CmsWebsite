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

        [HttpPost("[action]")]
        public async Task<IActionResult> Upload([Required] IList<IFormFile> UploadFiles, string? subDirectory)
        {
            try
            {
                foreach (var file in UploadFiles)
                {
                    if (UploadFiles != null)
                    {
                        if (file == null || file.Length == 0) return BadRequest("Upload a file");

                        var result = await _fileService.UploadFile(file, subDirectory);
                        Response.Headers.Add("name",result.fileName);
                        Response.Headers.Add("loadpath", result.loadPathFile);

                        return Ok(result);
                    }
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        #endregion

        #region Delete  
        [HttpDelete(nameof(Delete))]
        public async Task<ActionResult<bool>> Delete( string fileName)
        {
            try
            {
                if (fileName == null ) return BadRequest("Undefined a file name");

                var result = await _fileService.DeleteFile(fileName);

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