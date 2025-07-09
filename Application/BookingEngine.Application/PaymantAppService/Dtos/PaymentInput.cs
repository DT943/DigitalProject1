using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingEngine.Application.WrappingAppService.WrappingBookingAppService.Dtos;

namespace BookingEngine.Application.PaymantAppService.Dtos
{
    public class PaymentCreateDto 
    {
        public StripeInfoDto StripeInfo { get; set; }
        public BookCreateDto BookingInfo { get; set; }
    }
}
