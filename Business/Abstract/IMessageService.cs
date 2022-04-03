using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMessageService
    {
        IResult Send(MessageDto message, FileDto fileDto);
        IDataResult<List<MessageWithFileDto>> GetAllMessagesAndList(string karsiKisiUserName, string kendisiUserName);
        IResult AllMessageDelete(string karsiUserName,string gonderenUserName);


    }
}
