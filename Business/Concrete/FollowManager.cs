using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class FollowManager : IFollowService
    {
        IFollowDal _followDal;
        IUserService _userService;

        public FollowManager(IFollowDal followDal, IUserService userService)
        {
            _followDal = followDal;
            _userService = userService;
        }

        public IResult Follow(Follow follow)
        {
            IResult result = BusinessRules.Run(IsAlreadyFollowing(follow), IsThereTheUser(follow),IsYourself(follow), CanItBeFollowed(follow));
            if (result != null)
            {
                return result;
            }
         
            _followDal.Add(follow);
            return new SuccessResult(Messages.Followed);
        }

        public IDataResult<Follow> IsFollow(Follow follow)
        {
            IResult result = BusinessRules.Run(IsAlreadyFollowing(follow),IsThereTheUser(follow));
            if (result !=null)
            {
                var result2 = GetFollowByUserName(follow.TakipEden, follow.TakipEdilen);
                return result2;
            }
            return new SuccessDataResult<Follow>(null, Messages.YouAreNotFollowingTheUser);
        }

       

        public IResult Unfollow(Follow follow)
        {
            Follow follow1 = _followDal.Get(p => p.TakipEden == follow.TakipEden && p.TakipEdilen == follow.TakipEdilen);
            if (follow1 !=null)
            {
                _followDal.Delete(follow1);
                return new SuccessResult(Messages.UnFollowed);
            }
            return new ErrorResult("Takipten çıkma başarısız");
           
        }

        public IDataResult<int> NumberOfFollowers(string userName)
        {
            int result = _followDal.GetAll(p => p.TakipEdilen == userName).ToList().Count();
            return new SuccessDataResult<int>(result,Messages.NumberOfFollowers);
        }

        private IResult IsAlreadyFollowing(Follow follow)
        {
            var result = _followDal.GetList(p => p.TakipEdilen == follow.TakipEdilen && p.TakipEden == follow.TakipEden).Any();
            if (result)
            {
                return new ErrorResult(Messages.YouAreAlreadyFollowingTheUser);
            }
            return new SuccessResult();
        }
        private IDataResult<Follow> GetFollowByUserName(string kendiUserName, string karsiUserName)
        {
            Follow result = _followDal.Get(p => p.TakipEden == kendiUserName && p.TakipEdilen == karsiUserName);
            if (result != null)
            {
                return new SuccessDataResult<Follow>(result, "getirildi");
            }
            return new ErrorDataResult<Follow>(result, "getirme baş<rısız");
        }

        private IResult IsYourself(Follow follow)
        {
            if (follow.TakipEden==follow.TakipEdilen)
            {
                return new ErrorResult(Messages.YouCantFollowYourself);
            }
            return new SuccessResult();
        }

        //Sadece doktor ve yetkili kişi olanlar takip edilebilir
        private IResult CanItBeFollowed(Follow follow)
        {
            int claims = _userService.GetClaimsNameByUserName(follow.TakipEdilen).Count();
            if (claims>0)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.ThisUserCannotBeFollowed) ;
        }

        private IResult IsThereTheUser(Follow follow)
       {
           var result = _userService.GetByUserName(follow.TakipEdilen);
           if (result !=null)
           {
               return new SuccessResult();
           }
           return new ErrorResult(Messages.ThereIsNoSuchUser);

       }

       
    }
}
