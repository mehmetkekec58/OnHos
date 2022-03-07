using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<OperationClaim> GetClaims(User user)
        {
           
            return _userDal.GetClaims(user);
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        public IDataResult<UserDetailDto> GetUserDetail(string userName)
        {
            return new SuccessDataResult<UserDetailDto>(_userDal.GetProfileDetail(userName));
           

        }

        public User GetByUserName(string userName)
        {
            return _userDal.Get(p=>p.UserName==userName);
        }


        public List<string> GetClaimsNameByUserName(string userName)
        {
            List<string> claims = new List<string> { };   
            foreach (OperationClaim item in _userDal.GetClaimsNameByUserName(userName))
            {
                claims.Add(item.Name);
            } 
            return claims;
        }

        public IDataResult<List<string>> GetClaimNameByUserName(string userName)
        {
            return new SuccessDataResult<List<string>>(GetClaimsNameByUserName(userName).ToArray().Length==0? null : GetClaimsNameByUserName(userName));
        }

        public IDataResult<List<UserDetailDto>> GetDoctors()
        {
            return new SuccessDataResult<List<UserDetailDto>>(_userDal.GetDoctors());
        }
    }
}
