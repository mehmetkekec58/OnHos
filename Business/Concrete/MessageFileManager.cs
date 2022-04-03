using Business.Abstract;
using Business.Constants;
using Business.Helper.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MessageFileManager : IMessageFileService
    {
        IMessageFileDal _messageFileDal;
 

        public MessageFileManager(IMessageFileDal messageFileDal)
        {
            _messageFileDal = messageFileDal;
         
        }

        public IResult Upload(MessageFile messageFile)
        {
                _messageFileDal.Add(messageFile);
                return new SuccessResult();
           
            
           
          
        }


    }
}
