using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingEngine.Application.StripeSessionDataAppService.Dtos
{
    public class StripeSessionDataGetDto
    {
        public int Id { get; set; }
        public string Pnr { get; set; }
        public string PassengerInfoJson { get; set; }
        public string PassengersJson { get; set; }
        public string TravelersJson { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
