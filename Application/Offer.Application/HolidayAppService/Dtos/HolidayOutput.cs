using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Offer.Application.HolidayAppService.Dtos
{
    public class HolidayGetDto
    {
        public int Id { get; set; }
        public DateTime HolidayDate { get; set; }
        public int OfferID { get; set; }
    }
}
