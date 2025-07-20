using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace BookingEngine.Application.WrappingAppService.WrappingPaymentAppService.Dtos
{
    public class PaymentSystemGetDto
    {
        public List<string> Error { get; set; }

        public string Status {  get; set; }

        public string TicketAdvisory { get; set; }
    }

}
