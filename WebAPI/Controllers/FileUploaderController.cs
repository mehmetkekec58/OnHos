using Business.Helper.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FileUploaderController : ControllerBase
    {
        IFileUploadHelper _fileUploadHelper;

        public FileUploaderController(IFileUploadHelper fileUploadHelper)
        {
            _fileUploadHelper = fileUploadHelper;
        }

        [HttpPost("uploadphoto")]
        public IActionResult UploadPhoto(IFormFile file)
        {
          var result = _fileUploadHelper.Upload(file,"images");
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [Authorize(Roles = "Admin,Doctor")]
        [HttpPost("uploadvideo")]
        public IActionResult UploadVideo(IFormFile file)
        {
            var result = _fileUploadHelper.Upload(file,"videos");
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("uploadmessagefile")]
        public IActionResult UploadMessageFile(IFormFile file)
        {
            var result = _fileUploadHelper.Upload(file,"files");
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
