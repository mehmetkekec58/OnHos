using Business.Abstract;
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
    public class AboutManager : IAboutService
    {
        private IReadingListDal _aboutDal;

        public AboutManager(IReadingListDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void Add(string about, string userName)
        {
            _aboutDal.Add(new About
            {
                AboutMe=about,
                UserName=userName
            });
        }

        public IResult Update(About about)
        {         
            _aboutDal.Update(about);
            return new SuccessResult();
        }

      
    }
}
