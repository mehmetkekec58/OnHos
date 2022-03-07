using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        void Add(User user);
        User GetByMail(string email);
        User GetByUserName(string userName);
      //  bool GetUsersByUserName(string[] userName);
        List<string> GetClaimsNameByUserName(string userName);
        IDataResult<List<string>> GetClaimNameByUserName(string userName);
        IDataResult<UserDetailDto> GetUserDetail(string userName);
        IDataResult<List<UserDetailDto>> GetDoctors();
       
    }
}
