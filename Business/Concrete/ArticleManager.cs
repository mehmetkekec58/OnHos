using Business.Abstract;
using Business.Constants;
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
    public class ArticleManager : IArticleService
    {
        IArticleDal _articleDal;

        public ArticleManager(IArticleDal articleDal)
        {
            _articleDal = articleDal;
        }

        public IResult Add(ArticleDto articleDto)
        {

            _articleDal.Add(new Article
            {
                Text=articleDto.Text,
                Title=articleDto.Title,
                UserName=articleDto.UserName,
                PublishDate=DateTime.Now,
                EditDate=DateTime.Now
            });
            return new SuccessResult(Messages.ArticleAdded);
        }

        public IResult Delete(Article article)
        {
            _articleDal.Delete(article);
            return new SuccessResult(Messages.ArticleDeleted);
        }

        public IDataResult<List<Article>> GetAll()
        {
            return new SuccessDataResult<List<Article>>(_articleDal.GetList().ToList());
        }

        public IDataResult<Article> GetArticleById(int id)
        {
            return new SuccessDataResult<Article>(_articleDal.Get(p => p.Id == id));
        }

        public IDataResult<List<Article>> GetArticlesByUserName(string userName)
        {
           
            return new SuccessDataResult<List<Article>>(_articleDal.GetAll(p=>p.UserName==userName));
        }

        public IResult Update(Article article)
        {
            _articleDal.Update(article);
            return new SuccessResult(Messages.ArticleUpdate);
        }
    }
}
