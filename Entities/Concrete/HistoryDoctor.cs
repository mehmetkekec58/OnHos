using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class HistoryDoctor:IEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string DoctorUserName { get; set; }
        public DateTime Date { get; set; }
    }
}
