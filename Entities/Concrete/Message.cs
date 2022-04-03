using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Message:IEntity
    {
        public int Id { get; set; }
        public string GonderenUserName { get; set; }
        public string AlanUserName { get; set; }
        public string Text { get; set; }
        public string MessageType { get; set; }
        public DateTime Date { get; set ; }
        public bool AlanUserSildiMi { get; set; }
        public bool GonderenUserSildiMi { get; set; }


    }
}
