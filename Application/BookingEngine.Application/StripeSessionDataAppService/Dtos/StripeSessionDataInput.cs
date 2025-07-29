using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;

namespace BookingEngine.Application.StripeSessionDataAppService
{
    public class StripeSessionDataCreateDto : IValidatableDto
    {
        public string Pnr { get; set; }
        public string PassengerInfoJson { get; set; }
        public string PassengersJson { get; set; }
        public string TravelersJson { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
    public class StripeSessionDataUpdateDto : IEntityUpdateDto
    {

    }
}

