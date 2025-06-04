using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;

namespace CMS.Application.AirportsAppService.Dto
{
    public class AirportsCreateDto : IValidatableDto
    {
        public string AirportName { get; set; }

        public string AirportCode { get; set; }

        public string? ImageUrl { get; set; }
    }

    public class AirportsUpdateDto : IEntityUpdateDto
    {
        public string AirportName { get; set; }

        public string AirportCode { get; set; }

        public string? ImageUrl { get; set; }
    }
}
