using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
   public class ArticleDto:IDto
    { 
        public string UserName { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime? PublishDate { get; set; }
        public DateTime? EditDate { get; set; }
    }
}
