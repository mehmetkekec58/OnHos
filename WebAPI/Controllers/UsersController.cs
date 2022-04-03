using Business.Abstract;
using Core.Entities.Concrete;
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
    [Authorize]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private IAuthService _authService;

        public UsersController(IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }
        [AllowAnonymous]
       // [Authorize(Roles = "Admin")]
        [HttpGet("profiledetailbyusername")]
        public IActionResult GetProfile(string userName)
        {   
            var result = _userService.GetUserDetail(userName);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [AllowAnonymous]
        [HttpGet("getclaimnamebyusername")]
        public IActionResult GetClaimNameByUserName(string userName)
        {
            var result = _userService.GetClaimNameByUserName(userName);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }
        [AllowAnonymous]
        [HttpGet("getusernamebytoken")]
        public IActionResult GetUserNameByToken()
        {
            var takipEdenUserName = _userService.GetUserNameByToken(HttpContext);
            if (takipEdenUserName.Success)
            {
                return Ok(takipEdenUserName);

            }
            return BadRequest(takipEdenUserName);
        }

        [HttpPost("update")]
        public IActionResult Update(ProfileUpdateDto userDetailDto)
        {
            var userName = _userService.GetUserNameByToken(HttpContext);
            if (!userName.Success)
            {
                return BadRequest(userName);
            }
            var result1 = _userService.Update(userDetailDto, userName.Data);
            var result = _authService.CreateAccessToken(result1.Data);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
