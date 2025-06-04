using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Domain.Models;

namespace CMS.Domain.Models
{
    public class Airports : BasicEntity
    {
        public string AirportName { get; set; }

        public string AirportCode { get; set; }

        public string? ImageUrl { get; set; }
    }
}
