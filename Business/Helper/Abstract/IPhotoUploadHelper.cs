using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Helper.Abstract
{
    public interface IPhotoUploadHelper
    {
        string Upload(IFormFile file);
    }
}
