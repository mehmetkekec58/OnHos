using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class FollowsController : ControllerBase
    {
        private IFollowService _followService;
        private IUserService _userService;

        public FollowsController(IFollowService followService, IUserService userService)
        {
            _followService = followService;
            _userService = userService;
        }

        [HttpGet("follow")]
        public IActionResult Follow(string takipEdilecekUserName)
        {
           
            var takipEdenUserName = _userService.GetUserNameByToken(HttpContext);
            if (!takipEdenUserName.Success)
            {
                return BadRequest(takipEdenUserName);
            }
        
           
            var result = _followService.Follow(new Follow{
                TakipEden= takipEdenUserName.Data, 
                TakipEdilen=takipEdilecekUserName });
      
           
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("unfollow")]
        public IActionResult Unfollow(string karsiUserName)
        {
            var takipEdenUserName = _userService.GetUserNameByToken(HttpContext);
            if (!takipEdenUserName.Success)
            {
                return BadRequest(takipEdenUserName);

            }
        
            var result = _followService.Unfollow(new Follow { 
                TakipEden = takipEdenUserName.Data, TakipEdilen = karsiUserName });
           
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [AllowAnonymous]
        [HttpGet("isfollow")]
        public IActionResult IsFollow(string userName)
        {
            var takipEdenUserName = _userService.GetUserNameByToken(HttpContext);
            if (!takipEdenUserName.Success)
            {
                return BadRequest(takipEdenUserName);

            } 

            var result = _followService.IsFollow(new Follow
            {
                TakipEden=takipEdenUserName.Data,
                TakipEdilen= userName
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
