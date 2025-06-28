using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWCore.Application.LanguageAppService.Dtos
{
    public class LanguageGetDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string LanguageCode { get; set; }
        public bool IsActive { get; set; }
    }
}
