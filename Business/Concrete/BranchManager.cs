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
    public class BranchManager : IBranchService
    {
        IBranchDal _branchDal;

        public BranchManager(IBranchDal branchDal)
        {
            _branchDal = branchDal;
        }

        public IResult Add(string userName)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Branch> GetByUserName(string userName)
        {
            return new SuccessDataResult<Branch>(_branchDal.Get(p=>p.UserName==userName));
        }

        public IResult Update(Branch branch)
        {
            _branchDal.Update(branch);
           return new SuccessResult(Messages.BranchUpdated);
        }

        private IResult BranchKendisininMi(int id, string userName)
        {
            Branch branch = _branchDal.Get(p => p.Id == id);

            if (branch != null)
            {
                if (branch.UserName == userName)
                {
                    return new SuccessResult();
                }
                else
                {
                    return new ErrorResult("Başkasına branş ekleyemezsiniz");
                }
            }
            else
            {
                return new SuccessResult();
            }
        }
    }
}
