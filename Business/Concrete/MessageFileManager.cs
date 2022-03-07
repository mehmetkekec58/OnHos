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
        IFileUploadHelper _fileUploadHelper;

        public MessageFileManager(IMessageFileDal messageFileDal, IFileUploadHelper fileUploadHelper)
        {
            _messageFileDal = messageFileDal;
            _fileUploadHelper = fileUploadHelper;
        }

        public IResult Upload(IFormFile file ,int messageId)
        {
          var result =  _fileUploadHelper.Upload(file);
            if (result !=null)
            {
                _messageFileDal.Add(new MessageFile
                {
                 Url=result,
                 FileType=file.ContentType,
                 FileName=file.FileName,
                 Size = Convert.ToInt32(file.Length),
                 MessageId=messageId
                });
                return new SuccessResult();
            }
            
            return new ErrorResult(Messages.SomethingWentWrong);
          
        }


    }
}
