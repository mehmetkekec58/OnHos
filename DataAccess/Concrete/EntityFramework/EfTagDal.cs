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
    public class EfTagDal : EfEntityRepositoryBase<Tag, SqlContext>, ITagDal
    {
        public List<Tag> GetAllByArticleId(int id)
        {
            using (var context = new SqlContext())
            {
                var result = from a in context.Tags
                             join b in context.ArticleAndTag
                             on a.Id equals b.TagId
                             where a.Id == id
                             select new Tag
                             {
                                 Id = a.Id,
                                 TagName = a.TagName,

                             };
                return result.ToList();
            }

            }

        public List<Tag> GetAllByVideoId(int id)
        {
            using (var context = new SqlContext())
            {
                var result = from a in context.Tags
                             join b in context.VideoAndTag
                             on a.Id equals b.TagId
                             where a.Id == id
                             select new Tag
                             {
                                 Id = a.Id,
                                 TagName = a.TagName,

                             };
                return result.ToList();
            }
        }
    }
}
