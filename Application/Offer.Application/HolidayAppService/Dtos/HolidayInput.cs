using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;

namespace Offer.Application.HolidayAppService.Dtos
{
    public class HolidayCreateDto : IValidatableDto
    {
        public DateTime HolidayDate { get; set; }
        public int OfferID { get; set; }
    }

    public class HolidayUpdateDto : IEntityUpdateDto
    {
        public DateTime HolidayDate { get; set; }
        public int OfferID { get; set; }

    }
}
