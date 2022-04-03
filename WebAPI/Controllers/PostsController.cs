using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PostsController : ControllerBase
    {
        IPostService _postService;
        IUserService _userService;
        public PostsController(IPostService postService, IUserService userService)
        {
            _postService = postService;
            _userService = userService;
        }
        [AllowAnonymous]
        [HttpGet("getallbyusername")]
        public IActionResult GetAllByUserName(string userName)
        {
            var result = _postService.GetAllByUserName(userName);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [AllowAnonymous]
        [HttpGet("getpostbyid")]
        public IActionResult GetPostById(int id)
        {
            var result = _postService.GetPostById(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Authorize(Roles = "Admin,Doctor")]
        [HttpPost("share")]
        public IActionResult Share(Post post)
        {
            var userName = _userService.GetUserNameByToken(HttpContext);
            if (!userName.Success)
            {
                return BadRequest(userName);
            }
            var result = _postService.Share(new Post
            {
                UserName = userName.Data,
                Date=DateTime.Now,
                Image=post.Image,
                Text=post.Text,
            });

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [Authorize(Roles = "Admin,Doctor")]
        [HttpDelete("delete")]
        public IActionResult Delete(Post post)
        {
            var userName = _userService.GetUserNameByToken(HttpContext);
            if (!userName.Success)
            {
                return BadRequest(userName);
            }

            var result = _postService.Delete(new Post
            {
                UserName = userName.Data,
                Date = DateTime.Now,
                Image = post.Image,
                Text = post.Text,
            });

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Authorize(Roles = "Admin,Doctor")]
        [HttpPut("update")]
        public IActionResult Update(Post post)
        {

            var userName = _userService.GetUserNameByToken(HttpContext);
            if (!userName.Success)
            {
                return BadRequest(userName);
            }
            var result = _postService.Update(new Post
            {
                UserName = userName.Data,
                Date = DateTime.Now,
                Image = post.Image,
                Text = post.Text,
            });

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
