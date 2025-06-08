using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loyalty.Application.SegmentMilesRedemption.Dto
{
    public class SegmentMilesRedemptionGetDto
    {
        public int Id { get; set; }
        [MaxLength(10)]
        public string Origin { get; set; }

        [MaxLength(10)]
        public string Destination { get; set; }

        [MaxLength(10)]
        public string COS { get; set; }

        public int RedemptionValue { get; set; }
    }
}
