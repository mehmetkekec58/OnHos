using Business.Abstract;
using Business.Constants;
using Business.Helper.Abstract;
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
    //[Authorize]
    public class ArticlesController : ControllerBase
    {
        private IArticleService _articleService;
        private IHistoryArticleService _historyArticleService;
        private IUserService _userService;
        private IFileUploadHelper _fileUploadHelper;

        public ArticlesController(IArticleService articleService, IHistoryArticleService historyArticleService, IUserService userService, IFileUploadHelper fileUploadHelper)
        {
            _articleService = articleService;
            _historyArticleService = historyArticleService;
            _userService = userService;
            _fileUploadHelper = fileUploadHelper;
        }

        // [Authorize(Roles = "Admin,Doctor")]
        [HttpPost("add")]
        public IActionResult Add(ArticleDto articleDto)
        {
            string yol = null;
            var userName = _userService.GetUserNameByToken(HttpContext);
            if (!userName.Success)
            {
                return BadRequest(userName);
            }
            if (articleDto.File!=null)
            {
               yol = _fileUploadHelper.Upload(articleDto.File, "articleImages").Data.Url;
            }

            var result1 = _articleService.Add(new Article {ImageUrl=yol,
                EditDate=DateTime.Now, PublishDate=DateTime.Now ,Text=articleDto.Text,Title=articleDto.Title,UserName=userName.Data});
            if (result1.Success)
            {
                return Ok(result1);
            }

            return BadRequest(result1);
        }

       // [Authorize(Roles = "Admin,Doctor")]
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
                ImageUrl=article.ImageUrl,
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

       // [Authorize(Roles = "Admin,Doctor")]
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
