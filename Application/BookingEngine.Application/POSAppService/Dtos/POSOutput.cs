using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingEngine.Application.AirPortAppService.Dtos;

namespace BookingEngine.Application.POSAppService.Dtos
{
    public class POSGetDto
    {
        public int Id { get; set; }

        public string POSCode { get; set; }

        public ICollection<POSTranslationGetDto> POSTranslations { get; set; }
        public bool IsDeleted { get; set; }


    }

    public class POSTranslationGetDto
    {
        public string LanguageCode { get; set; }
        public string Name { get; set; }
    }

}
