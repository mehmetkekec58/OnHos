using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfArticleDal : EfEntityRepositoryBase<Article, SqlContext>, IArticleDal
    {
       /* public Article GetAllWithTagByUserName(string userName)
        {
            using (var context = new SqlContext())
            {
                var result = from a in context.Articles
                             join b in context.ArticleAndTag
                             on a.Id equals b.ArticleId
                             join c in conte xt.Tags
                             on b.TagId equals c.Id
                             select new 
            }
            }*/
    }
}
