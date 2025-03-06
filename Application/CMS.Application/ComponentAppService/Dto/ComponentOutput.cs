using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.ComponentAppService.Dto
{
    public class ComponentGetDto
    {
        public int SegmentID { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }
        public int Position { get; set; }
    }
}
