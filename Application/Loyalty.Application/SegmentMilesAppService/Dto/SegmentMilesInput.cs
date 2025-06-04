using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;

namespace Loyalty.Application.SegmentMilesAppService.Dto
{
    public class SegmentMilesCreateDto : IValidatableDto
    {
        public string Origin { get; set; }

        public string Destination { get; set; }

        public int Miles { get; set; }
    }


    public class SegmentMilesUpdateDto : IEntityUpdateDto
    {
        public string Origin { get; set; }

        public string Destination { get; set; }

        public int Miles { get; set; }
    }
}
