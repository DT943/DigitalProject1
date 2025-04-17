using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;

namespace CMS.Application.ComponentMetadataAppService.Dto
{
    public class ComponentMetadataCreateDto : IValidatableDto
    {
        public string Type { get; set; }
        public string Content { get; set; }
    }

    public class ComponentMetadataUpdateDto : IEntityUpdateDto
    {
        public string Type { get; set; }
        public string Content { get; set; }
    }
}
