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
           IResult result = BusinessRules.Run(IsAlreadyFollowing(follow),IsThereTheUser(follow),IsYourself(follow),CanItBeFollowed(follow));
            if (result != null)
            {
                return result;
            }

            _followDal.Add(follow);
            return new SuccessResult(Messages.Followed);


        }
        public IDataResult<bool> IsFollow(Follow follow)
        {
            IResult result = BusinessRules.Run(IsAlreadyFollowing(follow),IsThereTheUser(follow));
            if (result !=null)
            {
                return new SuccessDataResult<bool>(true, result.Message);
            }
            return new SuccessDataResult<bool>(false, Messages.YouAreNotFollowingTheUser);
        }

       

        public IResult Unfollow(Follow follow)
        {
            IResult result = BusinessRules.Run(/*IsThereTheUser(follow)*/);
            if (result != null)
            {
                _followDal.Delete(follow);
                return new SuccessResult(Messages.UnFollowed);
            }
            return new ErrorResult(Messages.SomethingWentWrong);
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
            foreach (OperationClaim item in _userService.GetClaimsNameByUserName(follow.TakipEdilen)) 
            {
                if (item.Name != "")
                {
                    return new SuccessResult();
                }
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
