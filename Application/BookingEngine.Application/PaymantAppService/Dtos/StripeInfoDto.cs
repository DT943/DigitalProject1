using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingEngine.Application.PaymantAppService.Dtos
{
    public class StripeInfoDto
    {
        public long Amount { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }

    }
}
