using Business.Helper.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Helper.Concrete
{
    public class FileUploadHelper : IFileUploadHelper
    {
        public string Upload(IFormFile file)
        {
            if (file != null)
            {
                string imageExtension = Path.GetExtension(file.FileName);


                string fileName = Guid.NewGuid() + imageExtension;

                string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/file/{fileName}");

                using var stream = new FileStream(path, FileMode.Create);

                file.CopyTo(stream);

                return path;
            }
            return null;
        }
    }
}
