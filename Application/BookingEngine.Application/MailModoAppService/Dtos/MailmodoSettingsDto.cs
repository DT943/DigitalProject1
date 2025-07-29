using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace BookingEngine.Application.MailModoAppService.Dtos
{
    public class MailmodoSettingsDto
    {
        public string ApiKey { get; set; }

        public string CampaignRoundTripBusinessBooking { get; set; }

        public string CampaignOneWayBusinessBooking { get; set; }

        public string CampaignOneWayEconomyBooking { get; set; }
        public string CampaignnRoundTripEconomyBooking { get; set; }

    }
}
