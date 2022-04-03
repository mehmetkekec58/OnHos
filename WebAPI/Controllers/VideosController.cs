using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class VideosController : ControllerBase
    {
        IVideoService _videoService;

        public VideosController(IVideoService videoService)
        {
            _videoService = videoService;
        }

        [HttpGet("getallbyusername")]
        public IActionResult GetAllByUserName(string userName)
        {
            var result = _videoService.GetAllByUserName(userName);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getallbycategoryid")]
        public IActionResult GetAllByCategoryId(int categoryId)
        {
            var result = _videoService.GetAllByCategoryId(categoryId);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }




        [HttpGet("getvideobyid")]
        public IActionResult GetVideoById(int id)
        {
            var result = _videoService.GetVideoById(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [Authorize(Roles = "Admin,Doctor")]
        [HttpDelete("videodelete")]
        public IActionResult VideoDelete(Video video)
        {
            var result = _videoService.Delete(video);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getnumberofvideobyusername")]
        public IActionResult GetNumberOfVideoByUserName(string userName)
        {
            var result = _videoService.GetNumberOfVideoByUserName(userName);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
