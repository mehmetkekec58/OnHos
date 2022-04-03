using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        void Add(User user);
        IDataResult<User> Update(ProfileUpdateDto profileUpdateDto,string userName);
        User GetByMail(string email);
        User GetByUserName(string userName);
        List<OperationClaim> GetClaimsNameByUserName(string userName);
        IDataResult<List<OperationClaim>> GetClaimNameByUserName(string userName);
        IDataResult<UserDetailDto> GetUserDetail(string userName);
        IDataResult<List<UserDetailDto>> GetDoctors();
        IDataResult<string> GetUserNameByToken(HttpContext httpContext);
    }
}
