using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Application.ComponentAppService.Dto;

namespace CMS.Application.SegmentAppService.Dtos
{
    public class SegmentGetDto
    {
        public int Id { get; set; }
        public int PageID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Position { get; set; }

        public ICollection<ComponentGetDto> Components { get; set; }

    }
}
