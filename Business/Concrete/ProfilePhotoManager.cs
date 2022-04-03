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
    public class ProfilePhotoManager : IProfilePhotoService
    {
        IProfilePhotoDal _profilePhotoDal;
        IPhotoUploadHelper _photoUploadHelper;

        public ProfilePhotoManager(IProfilePhotoDal profilePhotoDal, IPhotoUploadHelper photoUploadHelper)
        {
            _profilePhotoDal = profilePhotoDal;
            _photoUploadHelper = photoUploadHelper;
        }

        public void Add(string url,string userName)
        {

            _profilePhotoDal.Add(new ProfilePhoto
            {
                Url = url,
                UserName = userName,
                Date = DateTime.Now
            });
        }

        public IResult Delete(ProfilePhoto profile)
        {
            string defaultProfilePhotoUrl = "https://i1.wp.com/www.kagitvs.com/projedenizi/wp-content/uploads/2021/07/AnaResim-2.jpg?resize=495%2C400&ssl=1";

            _profilePhotoDal.Update(new ProfilePhoto
            {
                UserName = profile.UserName,
                Url = defaultProfilePhotoUrl,
                Id=profile.Id,
                Date=DateTime.Now
            });
            return new SuccessResult(Messages.profilePhotoRemoved);
            
        }

        public IDataResult<ProfilePhoto> GetProfilePhotoByUserName(string userName)
        {
         return new SuccessDataResult<ProfilePhoto>(_profilePhotoDal.Get(p=>p.UserName==userName));
        }

        public IResult Update(ProfilePhoto profilePhoto) 
        {
           
                _profilePhotoDal.Update(new ProfilePhoto
                {
                    UserName = profilePhoto.UserName,
                    Url = profilePhoto.Url,
                    Id = profilePhoto.Id,
                    Date = DateTime.Now
                    
                });
                return new SuccessResult(Messages.ProfilePhotoUploaded);
         

            }
           
           
        }
      
    }

