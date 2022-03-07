using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.jwt
{
    public class TokenDegerleri
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstNameAndLastName { get; set; }
        public string UserName { get; set; }
        public string[] Yetkiler { get; set; }
     
    }
}
