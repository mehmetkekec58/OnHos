using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Paketler:IEntity
    {
        public int Id { get; set; }
        public string PaketName { get; set; }
        public int Fiyat { get; set; }
        public int HosPuan { get; set; }

    }
}
