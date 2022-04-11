using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
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

        public IResult Add(Article articleDto)
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
            IResult result = BusinessRules.Run(YaziKendisininMi(article.Id, article.UserName));
            if (result !=null)
            {
                return result;
            }
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
           
            return new SuccessDataResult<List<Article>>(_articleDal.GetAll(p=>p.UserName==userName).OrderByDescending(x => x.PublishDate).ToList());
        }
        public IDataResult<int> GetNumberOfArticlesByUserName(string userName)
        {

            return new SuccessDataResult<int>(_articleDal.GetAll(p => p.UserName == userName).Count());
        }

        public IResult Update(Article article)
        {
            IResult result = BusinessRules.Run(YaziKendisininMi(article.Id, article.UserName));
            if (result != null)
            {
                return result;
            }
            _articleDal.Update(new Article
            {
                Id = article.Id,
                UserName = article.UserName,
                CategoryId = article.CategoryId,
                Text = article.Text,
                Title= article.Title,
                PublishDate = article.PublishDate,
                EditDate = DateTime.Now,
            });
            return new SuccessResult(Messages.ArticleUpdate);
        }
        private IResult YaziKendisininMi(int id, string userName)
        {
            Article article = _articleDal.Get(p=>p.Id == id);

            if (article != null)
            {
                if (article.UserName == userName)
                {
                    return new SuccessResult();
                }
                else
                {
                    return new ErrorResult("Yazı size ait değil");
                }
            }
            else
            {
                return new ErrorResult("Yazı bulunamadı");
            }
        }
    }
}
