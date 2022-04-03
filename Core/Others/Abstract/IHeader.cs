﻿using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Others.Abstract
{
    public interface IHeader
    {
        IDataResult<string> GetToken(HttpContext httpContext);
    }
}
