﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class BarberDtoForInsertion
    {
        public string Name { get; set; }
        public string Bio { get; set; }
        public string Location { get; set; }
    }
}
