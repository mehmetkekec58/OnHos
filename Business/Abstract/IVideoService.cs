using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IVideoService
    {
        IResult Upload(Video video);
        IResult Delete(Video video);

        IDataResult<List<Video>> GetAllByUserName(string userName);
        IDataResult<Video>  GetVideoById(int id);
        IDataResult<List<Video>>  GetAllByCategoryId(int categoryId);
        IDataResult<int>  GetNumberOfVideoByUserName(string userName);

 
    }
}
