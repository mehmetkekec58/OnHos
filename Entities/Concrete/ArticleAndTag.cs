using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ArticleAndTag:IEntity
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public int TagId { get; set; }

    }
}
