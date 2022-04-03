using Business.Constants;
using Business.Helper.Abstract;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Helper.Concrete
{
    public class PhotoUploadHelper : IPhotoUploadHelper
    {
        public IDataResult<string> Upload(IFormFile file)
        {
            if (file != null)
            {
                string imageExtension = Path.GetExtension(file.FileName);
              

                string imageName = Guid.NewGuid() + imageExtension;

                string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/{imageName}");

                using var stream = new FileStream(path, FileMode.Create);

                file.CopyTo(stream);

                return new SuccessDataResult<string>(path);
            }
            return new ErrorDataResult<string>("Dosya seçmediniz");
        }
        

    }
}
