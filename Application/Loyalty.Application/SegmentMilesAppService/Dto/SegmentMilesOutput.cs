using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loyalty.Application.SegmentMilesAppService.Dto
{
    public class SegmentMilesGetDto
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string BookingClass { get; set; }
        public string Description { get; set; }
        public string COS { get; set; }
        public int Miles { get; set; }
    }
}
