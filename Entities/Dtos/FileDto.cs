using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class FileDto:IDto
    {
        public string Url { get; set; }
        public string FileName { get; set; }
        public int Size { get; set; }
        public string FileType { get; set; }
    }
}
