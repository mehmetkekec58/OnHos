using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IReadingListsService
    {
        IDataResult<List<ReadingList>> GetAllByUserName(string userName);
        IResult Add(ReadingList list);
        IResult Delete(ReadingList list);

    }
}
