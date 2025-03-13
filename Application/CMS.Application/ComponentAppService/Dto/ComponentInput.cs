using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;

namespace CMS.Application.ComponentAppService.Dto
{
    public class ComponentCreateDto : IValidatableDto
    {
        public int SegmentID { get; set; }
        public string Type { get; set; }  
        public string Content { get; set; }  
        public int Position { get; set; }

    }

    public class ComponentUpdateDto : IEntityUpdateDto
    {
        public int SegmentID { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }
        public int Position { get; set; }

    }
}
