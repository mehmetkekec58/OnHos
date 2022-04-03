using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Video:IEntity
    {
        public int Id { get; set; }
        public string VideoUrl { get; set; }
        public string UserName { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Tag { get; set; }
        public int CategoryId { get; set; }
        public string KapakFoto { get; set; }

    }
}
