using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingEngine.Application.PaymantAppService.Dtos
{
    public class StripeInfoDto
    {
        public float Amount { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }

    }

  
    public class PricingInfoDto
    {
        public string PaxType { get; set; }

        public List<string> BaseFare { get; set; }

        public string TotalTax { get; set; }

        public string TotalFees { get; set; }

        public string TotalFare { get; set; }

        public List<string> Rules { get; set; }  

        public List<string> FareBasisCodes { get; set; }

        public List<string> SegmentCode { get; set; }
    }

}
