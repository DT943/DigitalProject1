﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWCore.Application.POSAppService.Dtos
{
    public class POSGetDto
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string? ArabicName { get; set; }
        public string? EnglishName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
