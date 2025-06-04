using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loyalty.Application.SegmentMilesAppService.Dto
{
    public class SegmentMilesGetDto
    {
        public string Origin { get; set; }

        public string Destination { get; set; }

        public int Miles { get; set; }
    }
}
