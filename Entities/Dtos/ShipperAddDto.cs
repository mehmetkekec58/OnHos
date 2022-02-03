﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class ShipperAddDto:IDto
    {
        public string CompanyName { get; set; }
        public string Phone { get; set; }
    }
}
