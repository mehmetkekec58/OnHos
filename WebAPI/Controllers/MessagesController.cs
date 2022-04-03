using Business.Abstract;
using Business.Helper.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MessagesController : ControllerBase
    {
        IMessageService _messageService;
        IUserService _userService;
        
        public MessagesController(IMessageService messageService, IUserService userService)
        {
            _messageService = messageService;
            _userService = userService;
          
        }

        [HttpGet("getallmessage")]
        public IActionResult GetAllMessage(string karsiKisiUserName)
        {
            var userName = _userService.GetUserNameByToken(HttpContext);
            if (!userName.Success)
            {
                return BadRequest(userName);
            }
            var result = _messageService.GetAllMessagesAndList(karsiKisiUserName, userName.Data);
            if (result.Success)
            {
                return Ok(result);
            }
          return BadRequest(result);

        }


        [HttpPost("send")]
        public IActionResult SendMessage(MessageDto messageDto)
        {           
            var userName = _userService.GetUserNameByToken(HttpContext);
            if (!userName.Success)
            {
                return  BadRequest(userName);
            }
            var result = _messageService.Send(new MessageDto
            {
                AlanUserName = messageDto.AlanUserName,
                GonderenUserName= userName.Data,
                Text = messageDto.Text,
            },messageDto.fileDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("allmessagesdelete")]
        public IActionResult AllMessagesDelete(string karsiUserName,string kendiUserName)
        {
            var result = _messageService.AllMessageDelete(karsiUserName, kendiUserName);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
