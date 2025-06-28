using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingEngine.Application.AirPortAppService.Dtos
{
    public class AirPortGetDto
    {
        public int Id { get; set; }

        public string IATACode { get; set; }

        public ICollection<AirPortTranslationGetDto> AirPortTranslations { get; set; }
    }

    public class AirPortTranslationGetDto
    {
        public string LanguageCode { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string AirPortName { get; set; }
    }
}
