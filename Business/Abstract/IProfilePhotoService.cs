using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface IProfilePhotoService
    {
        void Add(string Url,string userName);
        IDataResult<ProfilePhoto> GetProfilePhotoByUserName(string userName);
        IResult Update(ProfilePhoto profilePhoto);
        IResult Delete(ProfilePhoto profile);
       
   
    }
}
