using Core.Others.Abstract;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Others.Concrete
{
    public class Header : IHeader
    {    
        public IDataResult<string> GetToken(HttpContext httpContext)
        {
            string authHeader = httpContext.Request.Headers["Authorization"];
            
            if (authHeader==null)
            {
                return new ErrorDataResult<string>("Token Yok");
            }
          var token = authHeader.Split(" ")[1];
            return new SuccessDataResult<string>(token,"Token var");
        }
    }
}
