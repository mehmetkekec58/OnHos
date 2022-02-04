using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos;
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
    public class FollowsController : ControllerBase
    {
        IFollowService _followService;

        public FollowsController(IFollowService followService)
        {
            _followService = followService;
        }

        [HttpPost("takipet")]
        public IActionResult TakipEt(TakipEtDto takipEtDto)
        {

            var result = _followService.TakipEt(new Follow{
                TakipEden=takipEtDto.TakipEden, 
                TakipEdilen=takipEtDto.TakipEdilen });
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("takibibirak")]
        public IActionResult TakibiBirak(Follow follow)
        {
            var result = _followService.TakibiBirak(follow);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("takipediyormu")]
        public IActionResult TakipEdiyorMu(Follow follow)
        {
            var result = _followService.TakipEdiyorMu(follow);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
