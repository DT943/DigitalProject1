using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application.BasicDto;

namespace CMS.Application.ComponentMetadataAppService.Dto
{ 
    public class ComponentMetadataGetDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }

    }
}
