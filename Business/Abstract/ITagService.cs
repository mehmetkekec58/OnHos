using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITagService
    {
        IResult Add(string tagName);
        IResult Add(string[] tags);
        IResult Update(Tag tag);
        IResult Detele(Tag tag);
        IDataResult<List<Tag>> GetAll();
        IDataResult<Tag> Get(string tagName);
        IDataResult<List<Tag>> GetTagsNameByArticleId(int id);
        IDataResult<List<Tag>> GetTagsNameByVideoId(int id);
        


    }
}
