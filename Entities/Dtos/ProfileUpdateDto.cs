using Core.Entities;
using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class ProfileUpdateDto:IDto
    {
        public UserUpdateDto User { get; set; }
        public ProfilePhoto ProfilePhoto { get; set; }
        public About About { get; set; }

    }
}
