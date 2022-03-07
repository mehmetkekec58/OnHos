using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
        UserDetailDto GetProfileDetail(string userName);
        List<OperationClaim> GetClaimsNameByUserName(string userName);
        List<UserDetailDto> GetDoctors(Expression<Func<UserDetailDto, bool>> filter = null);



    }
}
