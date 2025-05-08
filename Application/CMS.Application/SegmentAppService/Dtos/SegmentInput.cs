using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Application.ComponentAppService.Dto;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;

namespace CMS.Application.SegmentAppService.Dtos
{
    public class SegmentCreateDto : IValidatableDto
    {
        public int PageID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Position { get; set; }

    }

    public class SegmentUpdateDto : IEntityUpdateDto
    {
        public int PageID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Position { get; set; }
        public ICollection<ComponentUpdateDto> Components { get; set; }

    }
}
