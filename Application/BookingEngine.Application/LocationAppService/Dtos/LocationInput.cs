using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;
using Sieve.Models;

namespace BookingEngine.Application.LocationAppService.Dtos
{
    public class LocationCreateDto : IValidatableDto
    {
        [Required]
        public string CountryCode { get; set; }

        [Required]
        public string LocationCode { get; set; }

        [Required]
        public string CountryName { get; set; }

    }
    public class LocationUpdateDto : IEntityUpdateDto
    {
        [Required]
        public string CountryCode { get; set; }

        [Required]
        public string LocationCode { get; set; }

        [Required]
        public string CountryName { get; set; }

    }
   

}
