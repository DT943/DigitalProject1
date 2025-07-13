using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingEngine.Application.LocationAppService.Dtos
{
    public class LocationGetDto 
    {
        public int Id { get; set; }
        [Required]
        public string CountryCode { get; set; }

        [Required]
        public string LocationCode { get; set; }

        [Required]
        public string CountryName { get; set; }

    }
}
