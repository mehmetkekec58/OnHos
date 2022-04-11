using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private ITagService _tagService;

        public TagsController(ITagService tagService)
        {
            _tagService = tagService;
        }
        [HttpGet("gettagsbyarticleid")]
        public IActionResult GetTagsByArticleId(int id)
        {
            var result = _tagService.GetTagsNameByArticleId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("gettagsbyvideoid")]
        public IActionResult GetTagsByVideoId(int id)
        {
            var result = _tagService.GetTagsNameByVideoId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _tagService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult GetTagsByArticleId(Tag tag)
        {
            var result = _tagService.Detele(tag);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
