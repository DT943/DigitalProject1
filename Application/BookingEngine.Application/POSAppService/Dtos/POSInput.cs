using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;

namespace BookingEngine.Application.POSAppService.Dtos
{
    public class POSCreateDto : IValidatableDto
    {
        [Required]
        [StringLength(10, MinimumLength = 1)]
        public string POSCode { get; set; }

        public ICollection<POSTranslationCreateDto> POSTranslations { get; set; }


    }

    public class POSUpdateDto : IEntityUpdateDto
    {
        [Required]
        [StringLength(10, MinimumLength = 1)]
        public string POSCode { get; set; }
        public ICollection<POSTranslationCreateDto> POSTranslations { get; set; }

    }


    public class POSTranslationCreateDto : IValidatableDto
    {

        [Required]
        public string LanguageCode { get; set; }

        [Required]
        public string Name { get; set; }

    }
    public class POSTranslationUpdateDto : IEntityUpdateDto
    {
        [Required]
        public string LanguageCode { get; set; }

        [Required]
        public string Name { get; set; }

    }

}












