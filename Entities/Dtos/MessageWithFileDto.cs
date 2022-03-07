using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class MessageWithFileDto:IDto
    {
        public string AlanUserName { get; set; }
        public string GonderenUserName{ get; set;}
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public MessageFile File { get; set; }
        public int MessageId { get; set; }

    }
}

