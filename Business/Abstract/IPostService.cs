using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPostService
    {
        IResult Share(Post post);
        IResult Delete(Post post);
        IResult Update(Post post);
        IDataResult<Post> GetPostById(int postId);
        IDataResult<List<Post>> GetAllByUserName(string userName);
       
    }
}
