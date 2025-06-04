using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.AirportsAppService.Dto
{
    public class AirportsGetDto
    {
        public int Id { get; set; }
        public string AirportName { get; set; }

        public string AirportCode { get; set; }

        public string? ImageUrl { get; set; }
    }
}
