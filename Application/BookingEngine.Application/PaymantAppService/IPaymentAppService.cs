using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingEngine.Application.PassengerInfo.Dtos;
using BookingEngine.Application.PaymantAppService.Dtos;

namespace BookingEngine.Application.PaymantAppService
{
    public interface IPaymentAppService
    {
        Task<string> CreateCheckoutSessionAsync( ICollection<PassengerInfoCreateDto> Passengers, List<Dictionary<string, string>> Travelers, List<PricingInfoDto> PassengerInfo, StripeSettingsDto settings, StripeInfoDto stripeInfo,string pnr,int  pos, string paymentAmount);
        Task HandleStripeWebhookAsync(string json, string stripeSignatureHeader, StripeSettingsDto settings);

    }
}
