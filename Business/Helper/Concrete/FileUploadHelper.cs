using Business.Helper.Abstract;
using Core.Utilities.Results;
using Entities.Dtos;
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
        public IDataResult<FileDto> Upload(IFormFile file, string yol)
        {
            if (file != null)
            {
                string imageExtension = Path.GetExtension(file.FileName);


                string fileName = Guid.NewGuid() + imageExtension;

                string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/{yol}/{fileName}");

                using var stream = new FileStream(path, FileMode.Create);

                file.CopyTo(stream);

                return new SuccessDataResult<FileDto>(new FileDto { Url=path, FileName = file.FileName, FileType = file.ContentType, Size = Convert.ToInt32(file.Length) } ,"Dosya yüklendi");
            }
            return new ErrorDataResult<FileDto>("Dosya seçmediniz");
        }
    }
}
