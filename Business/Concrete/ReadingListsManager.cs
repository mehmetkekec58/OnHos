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
    public class ReadingListsManager : IReadingListsService
    {
        IReadingListsDal _readingListsDal;

        public ReadingListsManager(IReadingListsDal readingListsDal)
        {
            _readingListsDal = readingListsDal;
        }

        public IResult Add(ReadingList list)
        {
            _readingListsDal.Add(list);
            return new SuccessResult(Messages.AddedToReadingList);
        }

        public IResult Delete(ReadingList list)
        {
           _readingListsDal.Delete(list);
            return new SuccessResult(Messages.DeletedFromReadingList);
        }

        public IDataResult<List<ReadingList>> GetAllByUserName(string userName)
        {
            return new SuccessDataResult<List<ReadingList>>(_readingListsDal.GetAll(p=>p.UserName==userName));
        }
    }
}
