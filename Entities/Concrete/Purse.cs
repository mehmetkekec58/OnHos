using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Purse:IEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int ParaMiktari { get; set; }

    }
}
