using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingEngine.Domain.Models;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;

namespace BookingEngine.Application.AirPortAppService.Dtos
{
    public class AirPortCreateDto: IValidatableDto
    {
        [Required]
        [StringLength(10, MinimumLength = 3)]
        public string IATACode { get; set; }

        public ICollection<AirPortTranslationCreateDto> AirPortTranslations { get; set; }

    }
    public class AirPortUpdateDto : IEntityUpdateDto
    {
        [Required]
        [StringLength(10, MinimumLength = 3)]
        public string IATACode { get; set; }
        public ICollection<AirPortTranslationCreateDto> AirPortTranslations { get; set; }

    }

    public class AirPortTranslationCreateDto : IValidatableDto {

        [Required]
        public string LanguageCode { get; set; }

        [Required]
        [StringLength(100)]
        public string City { get; set; }

        [Required]
        [StringLength(100)]
        public string Country { get; set; }

        [Required]
        [StringLength(150)]
        public string AirPortName { get; set; }
    }


    public class AirPortTranslationUpdateDto : IEntityUpdateDto
    {
        [Required]
        public string LanguageCode { get; set; }

        [Required]
        [StringLength(100)]
        public string City { get; set; }

        [Required]
        [StringLength(100)]
        public string Country { get; set; }

        [Required]
        [StringLength(150)]
        public string AirPortName { get; set; }

    }


}
