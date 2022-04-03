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
    public class HistoryArticleManager : IHistoryArticleService
    {
        IHistoryArticleDal _historyArticleDal;

        public HistoryArticleManager(IHistoryArticleDal historyArticleDal)
        {
            _historyArticleDal = historyArticleDal;
        }

        public void Add(string userName, int articleId)
        {
            _historyArticleDal.Add(new HistoryArticle
            {
                UserName = userName,
                ArticleId = articleId,
                Date = DateTime.Now,
            });
        }

        public IResult DeleteHistoryItem(HistoryArticle historyArticle)
        {
            _historyArticleDal.Delete(historyArticle);
            return new SuccessResult(Messages.DeletedFromHistory);
        }

        public IDataResult<List<HistoryArticle>> GetAllByUserName(string UserName)
        {
            return new SuccessDataResult<List<HistoryArticle>>(_historyArticleDal.GetAll(p => p.UserName == UserName).OrderByDescending(x=>x.Date).ToList());
        }
    }
}
