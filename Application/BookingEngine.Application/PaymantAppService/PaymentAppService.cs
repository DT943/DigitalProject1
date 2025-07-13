using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookingEngine.Application.PaymantAppService.Dtos;
using Stripe.Checkout;
using Stripe;
using BookingEngine.Domain.Models;
using System.Text.Json;
using CheckoutSession = Stripe.Checkout.Session;
using BookingEngine.Application.WrappingAppService.WrappingInquirePNRAppService;
using BookingEngine.Application.OTAUserAppService;
using System.Security.AccessControl;
using BookingEngine.Application.WrappingAppService.WrappingPaymentAppService.Dtos;
using BookingEngine.Application.WrappingAppService.WrappingPaymentAppService;



namespace BookingEngine.Application.PaymantAppService
{
    public class PaymentAppService : IPaymentAppService
    {
        private readonly IStripeResultAppService _stripeResultAppService;
        private readonly IWrappingInquirePNRAppService _wrappingInquirePNRAppService;
        private readonly IOTAUserAppService _oTAUserAppService;
        private IEncryptionAppService _encryptionAppService;

        private IWrappingPaymentAppService _wrappingPaymentAppService;

        public PaymentAppService(IStripeResultAppService stripeResultAppService, 
            IWrappingInquirePNRAppService wrappingInquirePNRAppService,
            IOTAUserAppService oTAUserAppService,
            IWrappingPaymentAppService wrappingPaymentAppService,
            IEncryptionAppService encryptionAppService)
        {
            _stripeResultAppService = stripeResultAppService;
            _wrappingInquirePNRAppService = wrappingInquirePNRAppService;
            _oTAUserAppService = oTAUserAppService;
            _encryptionAppService = encryptionAppService;
            _wrappingPaymentAppService = wrappingPaymentAppService;

        }

        public async Task<string> CreateCheckoutSessionAsync(StripeSettingsDto settings, StripeInfoDto stripeInfo , string pnr, int pos)
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
                SuccessUrl = "http://flycham.com/booking-confirm?session_id={CHECKOUT_SESSION_ID}",
                CancelUrl = "http://flycham.com/booking-rejected",
                //ExpiresAt = DateTime.UtcNow.AddMinutes(1)
                ExpiresAt = DateTime.UtcNow.AddMinutes(35),
                Metadata = new Dictionary<string, string>
                {
                    { "pnr", pnr },
                    { "pos", pos.ToString()}

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
                    settings.WebhookSecret,
                    tolerance: 300,
                    throwOnApiVersionMismatch: false  // <- Add this

                );
            }
            catch (StripeException ex)
            {
                Console.WriteLine("Stripe signature verification failed: " + ex.Message);
                throw;
            }
            try
            {
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
                    var posId = session.Metadata != null && session.Metadata.ContainsKey("pos")
                        ? session.Metadata["pos"]
                        : "0";


                    var oTAUser = await _oTAUserAppService.GetByPOSId(int.Parse(posId));


                    oTAUser.EncryptedPassword = _encryptionAppService.Decrypt(oTAUser.EncryptedPassword);



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

                    var paymentSystem = "unpaid";

                    if (session.PaymentStatus == "paid")
                    {

                        var inquirePNR = await _wrappingInquirePNRAppService.InquirePNRwithoutCheckAsync(pnr, oTAUser.UserName, oTAUser.EncryptedPassword);

                        if (inquirePNR != null && inquirePNR.Status != "error")
                        {

                            if (inquirePNR.TicketAdvisory.Contains("Reservation is onhold"))
                            {
                                var createPayment = new PaymentSystemCreateDto
                                {
                                    TransactionIdentifier = "",
                                    PNR = pnr,
                                    Balance = session.AmountTotal ?? 0,
                                    UserName = oTAUser.UserName,
                                    Password = oTAUser.EncryptedPassword,
                                    CompanyName = oTAUser.CompanyName
                                };

                                var res = await _wrappingPaymentAppService.PaymentAsync(createPayment);

                                paymentSystem = res.TicketAdvisory;

                            }

                        }
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
                        SystemPaymentState = paymentSystem,
                        ExpiresAt = DateTime.UtcNow,
                        MetadataJson = JsonSerializer.Serialize(session.Metadata),
                        CreationTime = DateTime.UtcNow
                    };

                    var StripeResult = await _stripeResultAppService.Create(stripeResult);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
    }
}