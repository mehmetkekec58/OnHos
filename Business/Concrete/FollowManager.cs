using Business.Abstract;
using Business.Constants;
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

        public FollowManager(IFollowDal followDal)
        {
            _followDal = followDal;
        }

        public IResult TakibiBirak(Follow follow)
        {
            IResult result = BusinessRules.Run(ZatenTakipEdiliyorMu(follow));
            if (result != null)
            {
                _followDal.Add(follow);
                return new SuccessResult(Messages.TakipEdildi);
            }

            return new ErrorResult();

          
        }

        public IDataResult<TakipEdiyorMu> TakipEdiyorMu(Follow follow)
        {
            var result = _followDal.GetList(p => p.TakipEdilen == follow.TakipEdilen && p.TakipEden == follow.TakipEden).Any();
            if (result)
            {
                return new SuccessDataResult<TakipEdiyorMu>();
            }
            return new ErrorDataResult<TakipEdiyorMu>();
        }

        public IResult TakipEt(Follow follow)
        {
            
            _followDal.Delete(follow);
            return new SuccessResult(Messages.TakiptenCikildi);
        }

        private IResult ZatenTakipEdiliyorMu(Follow follow)
        {
            var result = _followDal.GetList(p => p.TakipEdilen == follow.TakipEdilen && p.TakipEden == follow.TakipEden).Count();
            if (result>0)
            {
                return new ErrorResult(Messages.KullaniciyiZatenTakipEdiyorsun);
            }
            return new SuccessResult();
        }
    }
}
