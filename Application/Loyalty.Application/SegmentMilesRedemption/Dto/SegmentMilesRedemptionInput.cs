using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;

namespace Loyalty.Application.SegmentMilesRedemption.Dto
{
    public class SegmentMilesRedemptionCreateDto : IValidatableDto
    {
        [MaxLength(10)]
        public string Origin { get; set; }

        [MaxLength(10)]
        public string Destination { get; set; }

        [MaxLength(10)]
        public string COS { get; set; }

        public int RedemptionValue { get; set; }
    }


    public class SegmentMilesRedemptionUpdateDto : IEntityUpdateDto
    {
        [MaxLength(10)]
        public string Origin { get; set; }

        [MaxLength(10)]
        public string Destination { get; set; }

        [MaxLength(10)]
        public string COS { get; set; }

        public int RedemptionValue { get; set; }
    }
}
