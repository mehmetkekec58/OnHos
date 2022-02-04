using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
   public class TakipEtDto:IDto
    {
        public string TakipEden { get; set; }
        public string TakipEdilen { get; set; }
    }
}
