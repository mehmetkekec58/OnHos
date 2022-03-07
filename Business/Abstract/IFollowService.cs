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
        IResult Follow(Follow follow);
        IResult Unfollow(Follow follow);
        IDataResult<bool> IsFollow(Follow follow);
        IDataResult<int> NumberOfFollowers(string userName);  


    }
}
