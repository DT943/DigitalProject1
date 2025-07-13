using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;

namespace BookingEngine.Application.AmenitiesAppService.Dtos
{
    public class AmenityCreateDto : IValidatableDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

    }
    public class AmenityUpdateDto : IEntityUpdateDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

    }

}
