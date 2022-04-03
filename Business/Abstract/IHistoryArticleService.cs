using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IHistoryArticleService
    {
        IDataResult<List<HistoryArticle>> GetAllByUserName(string UserName);
        void Add(string userName, int articleId);
        IResult DeleteHistoryItem(HistoryArticle historyArticle);
       
    }
}
