using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingEngine.Application.PaymantAppService.Dtos
{
    public class StripeSettingsDto
    {
        public string SecretKey { get; set; }
        public string PublishableKey { get; set; }
        public string WebhookSecret { get; set; }

    }

}
