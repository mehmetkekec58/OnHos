using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        IMessageService _messageService;

        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet("getallmessage")]
        public IActionResult GetAllMessage(string karsiKisiUserName, string kendiUserName)
        {
            var result = _messageService.GetAllMessagesAndList(karsiKisiUserName, kendiUserName);
            if (result.Success)
            {
                return Ok(result);
            }
          return BadRequest(result);

        }


        [HttpPost("send")]
        public IActionResult SendMessage(MessageDto messageDto , IFormFile file)
        {
            var result = _messageService.Send(messageDto, null);
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
