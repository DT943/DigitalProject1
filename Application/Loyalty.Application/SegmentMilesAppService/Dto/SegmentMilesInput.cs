using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;

namespace Loyalty.Application.SegmentMilesAppService.Dto
{
    public class SegmentMilesCreateDto : IValidatableDto
    {
        [MaxLength(10)]
        public string Origin { get; set; }

        [MaxLength(10)]
        public string Destination { get; set; }

        [MaxLength(10)]
        public string BookingClass { get; set; }

        public string Description { get; set; }
        [MaxLength(10)]
        public string COS { get; set; }

        public int Miles { get; set; }
    }


    public class SegmentMilesUpdateDto : IEntityUpdateDto
    {
        [MaxLength(10)]
        public string Origin { get; set; }

        [MaxLength(10)]
        public string Destination { get; set; }

        [MaxLength(10)]
        public string BookingClass { get; set; }

        public string Description { get; set; }
        [MaxLength(10)]
        public string COS { get; set; }

        public int Miles { get; set; }
    }
}
