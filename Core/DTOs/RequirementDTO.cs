﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class RequirementDTO
    {
        public uint Id {  get; set; }

        public string Name { get; set; }
        
        public string GetSearch { get; set; }
    }
}
