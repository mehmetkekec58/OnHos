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
    public interface IArticleService
    {
        IResult Add(ArticleDto articleDto);
        IResult Update(Article article);
        IResult Delete(Article article);
        IDataResult<List<Article>> GetAll();
        IDataResult<Article> GetArticleById(int id);
        IDataResult<List<Article>> GetArticlesByUserName(string userName);
        IDataResult<int> GetNumberOfArticlesByUserName(string userName);
    }
}
