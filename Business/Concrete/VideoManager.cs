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
    public class VideoManager : IVideoService
    {
        IVideoDal _videoDal;

        public VideoManager(IVideoDal videoDal)
        {
            _videoDal = videoDal;
        }

        public IResult Delete(Video video)
        {
          _videoDal.Delete(video);
            return new SuccessResult(Messages.VideoDeleted);
        }

        public IDataResult<List<Video>> GetAllByCategoryId(int categoryId)
        {
            return new SuccessDataResult<List<Video>>(_videoDal.GetAll(p=>p.CategoryId==categoryId));
        }

        public IDataResult<List<Video>> GetAllByUserName(string userName)
        {
            return new SuccessDataResult<List<Video>>(_videoDal.GetAll(p => p.UserName == userName));
        }

        public IDataResult<int> GetNumberOfVideoByUserName(string userName)
        {
           return new SuccessDataResult<int>(_videoDal.GetAll(p=>p.UserName == userName).Count());
        }

        public IDataResult<Video> GetVideoById(int id)
        {
           return new SuccessDataResult<Video>(_videoDal.Get(p=>p.Id==id));
        }

        public IResult Upload(Video video)
        {
            _videoDal.Update(video);
            return new SuccessResult(Messages.VideoUploaded);

        }
    }
}
