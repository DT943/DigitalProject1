using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingEngine.Application.PaymantAppService.Dtos;

namespace BookingEngine.Application.PaymantAppService
{
    public interface IPaymentAppService
    {
        Task<string> CreateCheckoutSessionAsync(StripeSettingsDto settings, StripeInfoDto stripeInfo,string pnr,int  pos);
        Task HandleStripeWebhookAsync(string json, string stripeSignatureHeader, StripeSettingsDto settings);

    }
}
