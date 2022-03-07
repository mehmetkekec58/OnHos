using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;
        IMessageFileService _messageFileService;

        public MessageManager(IMessageDal messageDal, IMessageFileService messageFileService)
        {
            _messageDal = messageDal;
            _messageFileService = messageFileService;
        }

        public IResult AllMessageDelete(string karsiUserName, string gonderenUserName)
        {
            List<Message> messages= new List<Message>();
            messages = _messageDal.GetAll(p=>p.AlanUserName==karsiUserName && p.GonderenUserName==gonderenUserName || p.AlanUserName==gonderenUserName && p.GonderenUserName==karsiUserName).ToList();
            foreach (Message message in messages)
            {
                _messageDal.Delete(message);
            }
            return new SuccessResult(Messages.AllMessagesDeleted);

        }

        public IDataResult<List<MessageWithFileDto>> GetAllMessagesAndList(string karsiKisiUserName, string kendisiUserName)
        {
            return new SuccessDataResult<List<MessageWithFileDto>>(_messageDal.GetAllMessagesAndList(karsiKisiUserName, kendisiUserName));
        }

        public IResult Send(MessageDto message,IFormFile file)
        {
            
            Message messages = new Message();

            messages.AlanUserName = message.AlanUserName;
            messages.GonderenUserName = message.GonderenUserName;
            messages.MessageType = file == null ? "text" : file.ContentType;
            messages.Text = message.Text;
            messages.Date = DateTime.Now;

            
            _messageDal.Add(messages);

            if (file != null)
            { 
              int result =  _messageDal.Get(p=>p.AlanUserName==messages.AlanUserName && p.GonderenUserName==messages.GonderenUserName && p.Date==messages.Date && p.Text==messages.Text && p.MessageType==messages.MessageType).Id;
              _messageFileService.Upload(file,result);

            }
            return new SuccessResult();
        }
        

        /* public IDataResult<List<Message>> GetList(string karsıKisiUserName, string kendisiUserName)
       {
          return new SuccessDataResult<List<Message>>(_messageDal.GetAll(p=>p.AlanUserName==karsıKisiUserName && p.GonderenUserName==kendisiUserName
          || p.AlanUserName==kendisiUserName && p.GonderenUserName==karsıKisiUserName));
       }*/
    }
}
