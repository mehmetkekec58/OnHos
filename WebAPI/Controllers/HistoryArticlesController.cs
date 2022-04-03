using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryArticlesController : ControllerBase
    {
        IHistoryArticleService _historyArticleService;
        IUserService _userService;
        public HistoryArticlesController(IHistoryArticleService historyArticleService, IUserService userService)
        {
            _historyArticleService = historyArticleService;
            _userService = userService;
        }

        [HttpPost("add")]
        public void Add(int articleId)
        {
            var userName = _userService.GetUserNameByToken(HttpContext);
          
            _historyArticleService.Add(userName.Data,articleId);

        }
        [HttpDelete("delete")]
        public IActionResult Delete(HistoryArticle historyArticle)
        {
            var userName = _userService.GetUserNameByToken(HttpContext);
            if (!userName.Success)
            {
                return BadRequest(userName);
            }
            var result = _historyArticleService.DeleteHistoryItem(new HistoryArticle
            {
                Id = historyArticle.Id,
                Date = historyArticle.Date,
                ArticleId = historyArticle.ArticleId,
                UserName = userName.Data
            });
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallbyusername")]
 public IActionResult GetAllByUserName()
        {
            var userName = _userService.GetUserNameByToken(HttpContext);
            if (!userName.Success)
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
