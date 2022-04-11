using Business.Abstract;
using Core.Utilities.Business;
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
    public class VisitDoctorProfileManager : IVisitDoctorProfileService
    {
        IVisitDoctorProfileDal _visitDoctorprofileDal;

        public VisitDoctorProfileManager(IVisitDoctorProfileDal visitDoctorprofileDal)
        {
            _visitDoctorprofileDal = visitDoctorprofileDal;
        }

        public void Add(VisitDoctorProfile visit)
        {
            var result = BusinessRules.Run(ZatenVarMi(visit.UserIpAddress));
            if (result !=null)
            {
                _visitDoctorprofileDal.Add(new VisitDoctorProfile
                {
                    UserIpAddress = visit.UserIpAddress,
                    Date=DateTime.Now,
                    DoctorUserName = visit.DoctorUserName,
                   
                });
            }
            _visitDoctorprofileDal.Add(visit);
        }


        public IDataResult<List<VisitDoctorProfile>> GetAll()
        {

            return new SuccessDataResult<List<VisitDoctorProfile>>(_visitDoctorprofileDal.GetAll());
        }

        public IDataResult<List<VisitDoctorProfile>> GetByDate(VisitDoctorProfile visit)
        {
            throw new NotImplementedException();
        }
      
        private IResult ZatenVarMi(string userIpAddress)
        {
            var result = _visitDoctorprofileDal.GetAll(p => p.UserIpAddress == userIpAddress).Any();
            if (result)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
