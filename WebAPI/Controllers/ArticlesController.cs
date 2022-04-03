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
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ArticlesController : ControllerBase
    {
        private IArticleService _articleService;
        private IHistoryArticleService _historyArticleService;
        private IUserService _userService;

        public ArticlesController(IArticleService articleService, IHistoryArticleService historyArticleService, IUserService userService)
        {
            _articleService = articleService;
            _historyArticleService = historyArticleService;
            _userService = userService;
        }
       
        [Authorize(Roles = "Admin,Doctor")]
        [HttpPost("add")]
        public IActionResult Add(ArticleDto articleDto)
        {
            var userName = _userService.GetUserNameByToken(HttpContext);
            if (!userName.Success)
            {
                return BadRequest(userName);
            }
            var result = _articleService.Add(new ArticleDto {
                EditDate=null, PublishDate=null ,Text=articleDto.Text,Title=articleDto.Title,UserName=userName.Data});
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [Authorize(Roles = "Admin,Doctor")]
        [HttpPut("update")]
        public IActionResult Update(Article article)
        {
            var userName = _userService.GetUserNameByToken(HttpContext);
            if (!userName.Success)
            {
                return BadRequest(userName);
            }
            var result = _articleService.Update(new Article
            {
                Id=article.Id,
                UserName=userName.Data,
                CategoryId=article.CategoryId,
                EditDate=article.EditDate,
                PublishDate=article.PublishDate,
                Text=article.Text,
                Title =article.Title,
            });
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [Authorize(Roles = "Admin,Doctor")]
        [HttpDelete("delete")]
        public IActionResult Delete(Article article)
        {

            var result = _articleService.Delete(article);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [AllowAnonymous]
        [HttpGet("getall")]
        public IActionResult GetAll()
        {

            var result = _articleService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [AllowAnonymous]
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {

            var result = _articleService.GetArticleById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [AllowAnonymous]
        [HttpGet("getbyusername")]
        public IActionResult GetByUserName(string userName)
        {

            var result = _articleService.GetArticlesByUserName(userName);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [AllowAnonymous]
        [HttpGet("getnumberofarticlesbyusername")]
        public IActionResult GetNumberOfArticlesByUserName(string userName)
        {

            var result = _articleService.GetNumberOfArticlesByUserName(userName);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }



        [HttpGet("historygetall")]
        public IActionResult HistoryGetAllByUserName()
        {
          
            var userName = _userService.GetUserNameByToken(HttpContext);
                if(!userName.Success)
            {
                return BadRequest(userName);
            }
            var result = _historyArticleService.GetAllByUserName(userName.Data);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


    }
}
