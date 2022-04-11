using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class VideoAndTag:IEntity
    {
        public int Id { get; set; }
        public int VideoId { get; set; }
        public int TagId { get; set; }

    }
}
