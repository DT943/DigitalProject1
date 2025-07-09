using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookingEngine.Application.PaymantAppService.Dtos;
using Stripe.Checkout;
using Stripe;
using BookingEngine.Domain.Models;
using System.Text.Json;
using CheckoutSession = Stripe.Checkout.Session;



namespace BookingEngine.Application.PaymantAppService
{
    public class PaymentAppService : IPaymentAppService
    {
        private readonly IStripeResultAppService _stripeResultAppService;
         
        public PaymentAppService(IStripeResultAppService stripeResultAppService)
        {
            _stripeResultAppService = stripeResultAppService;
        }

        public async Task<string> CreateCheckoutSessionAsync(StripeSettingsDto settings, StripeInfoDto stripeInfo , string pnr)
        {
            StripeConfiguration.ApiKey = settings.SecretKey;
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                Mode = "payment",
                LineItems = new List<SessionLineItemOptions>
            {
                new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        Currency = stripeInfo.Currency,
                        UnitAmount = stripeInfo.Amount,
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = stripeInfo.Description
                        }
                    },
                    Quantity = 1
                }
            },
                SuccessUrl = "http://flycham.com?session_id={CHECKOUT_SESSION_ID}",
                CancelUrl = "http://flycham.com",
                //ExpiresAt = DateTime.UtcNow.AddMinutes(1)
                ExpiresAt = DateTime.UtcNow.AddMinutes(35),
                Metadata = new Dictionary<string, string>
                {
                    { "pnr", pnr }
                }

            };

            var service = new SessionService();
            var session = await service.CreateAsync(options);
            return session.Url;
        }

        public async Task HandleStripeWebhookAsync(string json, string stripeSignatureHeader, StripeSettingsDto settings)
        {
            Event stripeEvent;

            try
            {
                stripeEvent = EventUtility.ConstructEvent(
                    json,
                    stripeSignatureHeader,
                    settings.WebhookSecret
                );
            }
            catch (StripeException ex)
            {
                Console.WriteLine("Stripe signature verification failed: " + ex.Message);
                throw;
            }

            if (stripeEvent.Type == "checkout.session.completed")
            {
                if (stripeEvent.Data?.Object is not CheckoutSession session)
                {
                    Console.WriteLine("stripeEvent.Data.Object is null or not a Session.");
                    return;
                }

                //var session = stripeEvent.Data.Object as Session;

                var pnr = session.Metadata != null && session.Metadata.ContainsKey("pnr")
                    ? session.Metadata["pnr"]
                    : "UNKNOWN";
                var customerEmail = session.CustomerEmail
                                 ?? session.CustomerDetails?.Email
                                 ?? "not_provided";

                // Optional: fetch PaymentIntent to get PaymentMethodId
                string? paymentMethodId = null;
                if (!string.IsNullOrEmpty(session.PaymentIntentId))
                {
                    var paymentIntentService = new PaymentIntentService();
                    var paymentIntent = await paymentIntentService.GetAsync(session.PaymentIntentId);
                    paymentMethodId = paymentIntent?.PaymentMethodId;
                }

                var stripeResult = new StripeResultCreateDto
                {
                    SessionId = session.Id,
                    PaymentStatus = session.PaymentStatus ?? "unknown",
                    Pnr = pnr,
                    CustomerId = session.CustomerId,
                    CustomerEmail = customerEmail,
                    PaymentIntentId = session.PaymentIntentId,
                    PaymentMethodId = paymentMethodId,
                    AmountTotal = session.AmountTotal ?? 0,
                    Currency = session.Currency,
                    Mode = session.Mode,
                    Status = session.Status,
                    ExpiresAt = DateTime.UtcNow,
                    MetadataJson = JsonSerializer.Serialize(session.Metadata),
                    CreationTime = DateTime.UtcNow
                };

                try
                {
                    var StripeResult = await _stripeResultAppService.Create(stripeResult);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }


            }

        }
    }
}