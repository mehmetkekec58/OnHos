using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class FollowsController : ControllerBase
    {
        IFollowService _followService;

        public FollowsController(IFollowService followService)
        {
            _followService = followService;
        }

        [HttpPost("follow")]
        public IActionResult Follow(FollowDto takipEtDto)
        {

            var result = _followService.Follow(new Follow{
                TakipEden=takipEtDto.TakipEden, 
                TakipEdilen=takipEtDto.TakipEdilen });
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("unfollow")]
        public IActionResult Unfollow(Follow follow)
        {
            var result = _followService.Unfollow(follow);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
       // [AllowAnonymous]
        [HttpPost("isfollow")]
        public IActionResult IsFollow(FollowDto followDto)
        {
            var result = _followService.IsFollow(new Follow
            {
                TakipEden=followDto.TakipEden,
                TakipEdilen=followDto.TakipEdilen
            });
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [AllowAnonymous]
        [HttpGet("numberoffollowers")]
        public IActionResult NumberOfFollowers(string userName)
        {
            var result = _followService.NumberOfFollowers(userName)
                ;
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
