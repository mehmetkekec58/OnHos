using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IVisitDoctorProfileService
    {
        void Add(VisitDoctorProfile visit);
        IDataResult<List<VisitDoctorProfile>> GetByDate(VisitDoctorProfile visit);
        IDataResult<List<VisitDoctorProfile>> GetAll();

    }
}
