using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface IFollowService
    {
        IResult TakipEt(Follow follow);
        IResult TakibiBirak(Follow follow);
        IDataResult<TakipEdiyorMu> TakipEdiyorMu(Follow follow);
    }
}
