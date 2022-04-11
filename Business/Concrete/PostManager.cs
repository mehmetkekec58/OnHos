using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PostManager : IPostService
    {
        IPostDal _postDal;

        public PostManager(IPostDal postDal)
        {
            _postDal = postDal;
        }

        public IResult Delete(Post post)
        {
            _postDal.Delete(post);
            return new SuccessResult(Messages.PostDeleted);
        }

        public IDataResult<Post> GetPostById(int postId)
        {
            return new SuccessDataResult<Post>(_postDal.Get(p=>p.Id==postId));
        }

        public IDataResult<List<Post>> GetAllByUserName(string userName)
        {
           return new SuccessDataResult<List<Post>>(_postDal.GetAll(p=>p.UserName==userName).OrderByDescending(x=>x.Date).ToList());
        }

        public IResult Share(Post post)
        {
            _postDal.Add(post);
            return new SuccessResult(Messages.PostShared);
        }

        public IResult Update(Post post)
        {
            _postDal.Update(post);
            return new SuccessResult(Messages.PostUpdated);
        }
    }
}
