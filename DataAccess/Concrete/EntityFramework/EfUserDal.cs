using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, SqlContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new SqlContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserName == user.UserName
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }

        public UserDetailDto GetProfileDetail(string userName)
        {
            
            using (var context = new SqlContext())
            {
              
                var result = from a in context.ProfilePhotos
                             join b in context.Users
                             on a.UserName equals b.UserName
                             join c in context.Abouts
                             on b.UserName equals c.UserName
                             where b.UserName == userName
                             select new UserDetailDto
                             {
                                 UserName = userName,
                                 FirstName = b.FirstName,
                                 LastName = b.LastName,
                                 ProfilePhoto = new ProfilePhoto
                                 {
                                     Id=a.Id,
                                     UserName=a.UserName,
                                     Url=a.Url,
                                     Date=a.Date
                                 },
                                 AboutMe= new About
                                 {
                                     Id=c.Id,
                                     AboutMe=c.AboutMe,
                                     UserName=c.UserName
                                 }
                                  
                             };
                return result.ToList()[0];
               

            }
        } 

      
    }
}

