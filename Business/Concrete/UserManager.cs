using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Others.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        ITokenHelper _tokenHelper;
        IAboutService _aboutService;
        IProfilePhotoService _profilePhotoService;
        IHeader _header;
      

        public UserManager(IUserDal userDal, ITokenHelper tokenHelper, IAboutService aboutService, IProfilePhotoService profilePhotoService, IHeader header)
        {
            _userDal = userDal;
            _tokenHelper = tokenHelper;
            _aboutService = aboutService;
            _profilePhotoService = profilePhotoService;
            _header = header;
           
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
          
            UserDetailDto profileDetail = _userDal.GetProfileDetail(userName);
            if (profileDetail != null)
            {
                if (GetClaimsNameByUserName(userName).Count == 0)
                {
                    return new ErrorDataResult<UserDetailDto>(null, Messages.BoyleBirSaglikCalisaniYok);

                }
                return new SuccessDataResult<UserDetailDto>(_userDal.GetProfileDetail(userName));
            }
            return new ErrorDataResult<UserDetailDto>(null, Messages.UserNotFound);

        }

        public User GetByUserName(string userName)
        {
            return _userDal.Get(p=>p.UserName==userName);
        }


        public List<OperationClaim> GetClaimsNameByUserName(string userName)
        {
             
       return _userDal.GetClaimsNameByUserName(userName);
         
         
        }

        public IDataResult<List<OperationClaim>> GetClaimNameByUserName(string userName)
        {
            return new SuccessDataResult<List<OperationClaim>>(GetClaimsNameByUserName(userName));
        }

        public IDataResult<List<UserDetailDto>> GetDoctors()
        {
            return new SuccessDataResult<List<UserDetailDto>>(_userDal.GetDoctors());
        }

        public IDataResult<string> GetUserNameByToken(HttpContext httpContext)
        {
           var token = _header.GetToken(httpContext);
            if (!token.Success)
            {
                return token;
            }
            string userName = _tokenHelper.getUserNameByToken(token.Data);
            User user = _userDal.Get(p=>p.UserName == userName);
            if (user !=null)
            {
                return new SuccessDataResult<string>(user.UserName,"kullanıcı adı bulundu");
            }else{
                return new ErrorDataResult<string>(null, Messages.UserNotFound); 
            }
          
        }

        public IDataResult<User> Update(ProfileUpdateDto profileUpdateDto, string userName)
        {
            User user = GetByUserName(userName);
            if (profileUpdateDto.User.Password != "" && profileUpdateDto.User.Password != null)
            {
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(profileUpdateDto.User.Password, out passwordHash, out passwordSalt);

                User userUpdated = new User
                {
                    Id = user.Id,
                    FirstName = profileUpdateDto.User.FirstName,
                    LastName = profileUpdateDto.User.LastName,
                    Email = profileUpdateDto.User.Email,
                    Status = profileUpdateDto.User.Status,
                    UserName = profileUpdateDto.User.UserName,
                    PasswordHash=passwordHash,
                    PasswordSalt=passwordSalt

                };
                _userDal.Update(userUpdated);
                _aboutService.Update(profileUpdateDto.About);
                _profilePhotoService.Update(profileUpdateDto.ProfilePhoto);
                User user1 = GetByUserName(userUpdated.UserName);
                return new SuccessDataResult<User>(user1, Messages.AccessTokenCreated);
            }
            else
            {
                User userUpdated = new User
                {
                    Id = user.Id,
                    FirstName = profileUpdateDto.User.FirstName,
                    LastName = profileUpdateDto.User.LastName,
                    Email = profileUpdateDto.User.Email,
                    Status = profileUpdateDto.User.Status,
                    UserName = profileUpdateDto.User.UserName,


                };
                _userDal.Update(userUpdated);
                _aboutService.Update(profileUpdateDto.About);
                _profilePhotoService.Update(profileUpdateDto.ProfilePhoto);
                User user1 = GetByUserName(userUpdated.UserName);
                return new SuccessDataResult<User>(user1, Messages.AccessTokenCreated);
            }
 
        } 
    }
}
