using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface IShipperService
    {
        IResult Add(Shipper shipper);
        IResult Update(Shipper shipper);
        IDataResult<List<Shipper>>  GetAll();
        
       

    }
}
