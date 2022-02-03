using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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
    public class ShipperManager : IShipperService
    {
        private IShipperDal _shipperDal;

        public ShipperManager(IShipperDal shipperDal)
        {
            _shipperDal = shipperDal;
        }
        [ValidationAspect(typeof(ShipperValidator))]
        public IResult Add(Shipper shipper)
        {
            _shipperDal.Add(shipper);
            return new SuccessResult(Messages.NewShipperAdded);
        }

        public IDataResult<List<Shipper>> GetAll()
        {
            return new SuccessDataResult<List<Shipper>>(_shipperDal.GetList().ToList());
        }
        [ValidationAspect(typeof(ShipperValidator))]
        public IResult Update(Shipper shipper)
        {
            _shipperDal.Update(shipper);
            return new SuccessResult(Messages.ShipperUpdated);
        }
    }
}
