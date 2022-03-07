using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class MessageDto:IDto
    {
        public string GonderenUserName { get; set; }
        public string AlanUserName { get; set; }
        public string Text { get; set; }

    }
}
