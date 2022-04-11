using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Visit:IEntity
    {
        public int Id { get; set; }
        public string UserIpAddress { get; set; }
        public DateTime Date { get; set; }
    }
}
