﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.StaticComponentAppService.Dto
{ 
    public class StaticComponentGetDto
    {
        public int Id { get; set; }
         public string Type { get; set; }
        public string Content { get; set; }
        public int Position { get; set; }

    }

}
