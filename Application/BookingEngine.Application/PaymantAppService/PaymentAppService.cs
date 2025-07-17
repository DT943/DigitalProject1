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
using Microsoft.Extensions.Logging;
using System.Text;



namespace BookingEngine.Application.PaymantAppService
{
    public class PaymentAppService : IPaymentAppService
    {
        private readonly IStripeResultAppService _stripeResultAppService;
        private readonly IWrappingInquirePNRAppService _wrappingInquirePNRAppService;
        private readonly IOTAUserAppService _oTAUserAppService;
        private IEncryptionAppService _encryptionAppService;
        private readonly HttpClient _httpClient;

        private readonly ILogger<PaymentAppService> _logger;

        private IWrappingPaymentAppService _wrappingPaymentAppService;

        public PaymentAppService(IStripeResultAppService stripeResultAppService, 
            IWrappingInquirePNRAppService wrappingInquirePNRAppService,
            IOTAUserAppService oTAUserAppService,
            IWrappingPaymentAppService wrappingPaymentAppService,
            ILogger<PaymentAppService> logger,
            HttpClient httpClient,
            IEncryptionAppService encryptionAppService)
        {
            _stripeResultAppService = stripeResultAppService;
            _wrappingInquirePNRAppService = wrappingInquirePNRAppService;
            _oTAUserAppService = oTAUserAppService;
            _encryptionAppService = encryptionAppService;
            _wrappingPaymentAppService = wrappingPaymentAppService;
            _logger = logger;

            _httpClient = httpClient;

        }


        private int GetStripeCurrencyMultiplier(string currency)
        {
            switch (currency.ToUpper())
            {
                case "KWD":
                case "OMR":
                case "BHD":
                    return 1000;

                case "JPY":
                    return 1;

                default: 
                    return 100;
            }
        }

        public async Task<string> CreateCheckoutSessionAsync(StripeSettingsDto settings, StripeInfoDto stripeInfo , string pnr, int pos, string paymentAmount)
        {
            StripeConfiguration.ApiKey = settings.SecretKey;
            var multiplier = GetStripeCurrencyMultiplier(stripeInfo.Currency);

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
                        UnitAmount = (long)(stripeInfo.Amount * multiplier),
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
                    { "pos", pos.ToString() },
                    { "amount" , paymentAmount}

                }

            };
            _logger.LogInformation("Stripe Amount {am}", stripeInfo.Amount* multiplier);

            var service = new SessionService();
            var session = await service.CreateAsync(options);
            return session.Url;
        }

        public async Task HandleStripeWebhookAsync(string json, string stripeSignatureHeader, StripeSettingsDto settings)
        {
            Event stripeEvent;
            _logger.LogInformation("Starting Stripe webhook handling...");
            try
            {
                stripeEvent = EventUtility.ConstructEvent(
                    json,
                    stripeSignatureHeader,
                    settings.WebhookSecret,
                    tolerance: 300,
                    throwOnApiVersionMismatch: false  // <- Add this

                );
                _logger.LogInformation("Stripe event constructed successfully");

            }
            catch (StripeException ex)
            {
                _logger.LogError(ex, "Stripe signature verification failed: {Message}", ex.Message);
                throw;
            }
            try
            {
                if (stripeEvent.Type == "checkout.session.completed")
                {
                    try
                    {
                        if (stripeEvent.Data?.Object is not CheckoutSession session)
                        {
                            _logger.LogWarning("stripeEvent.Data.Object is null or not a Session.");
                            return;
                        }

                        //var session = stripeEvent.Data.Object as Session;
                        _logger.LogInformation("Checkout session completed: Session ID = {SessionId}", session.Id);

                        var pnr = session.Metadata != null && session.Metadata.ContainsKey("pnr")
                            ? session.Metadata["pnr"]
                            : "UNKNOWN";
                        var posId = session.Metadata != null && session.Metadata.ContainsKey("pos")
                            ? session.Metadata["pos"]
                            : "0";

                        var amountStr = session.Metadata != null && session.Metadata.ContainsKey("amount")
                            ? session.Metadata["amount"]
                            : "0";

                        if (!float.TryParse(amountStr, out float parsedAmount))
                        {
                            _logger.LogWarning("Invalid amount format received: {AmountStr}. Defaulting to 0.", amountStr);
                            parsedAmount = 0f;
                        }

                        _logger.LogInformation("PNR = {PNR}, POS ID = {POS}", pnr, posId);



                        var oTAUser = await _oTAUserAppService.GetByPOSId(int.Parse(posId));
                        _logger.LogInformation("OTA User retrieved: {UserName}", oTAUser.UserName);


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
                            _logger.LogInformation("Session is marked as PAID. Checking PNR status...");


                            var inquirePNR = await _wrappingInquirePNRAppService.InquirePNRwithoutCheckAsync(pnr, oTAUser.UserName, oTAUser.EncryptedPassword);

                            if (inquirePNR != null && inquirePNR.Status != "error")
                            {
                                _logger.LogInformation("InquirePNR Success. Ticket Advisory: {TicketAdvisory}", inquirePNR.TicketAdvisory);

                                if (inquirePNR.TicketAdvisory.Contains("Reservation is onhold"))
                                {
                                    _logger.LogInformation("Reservation is on hold. Proceeding to make payment...");

                                    var createPayment = new PaymentSystemCreateDto
                                    {
                                        TransactionIdentifier = inquirePNR.TransactionIdentifier,
                                        PNR = pnr,
                                        //Balance = session.AmountTotal/100 ?? 0,
                                        Balance = parsedAmount,//session.AmountTotal.HasValue ? session.AmountTotal.Value / 100f : 0f,
                                        UserName = oTAUser.UserName,
                                        Password = oTAUser.EncryptedPassword,
                                        CompanyName = oTAUser.CompanyName
                                    };

                                    var res = await _wrappingPaymentAppService.PaymentAsync(createPayment, session.Id);
                                    _logger.LogInformation("Payment response: {Res}", res);
                                    paymentSystem = res.TicketAdvisory;
                                    _logger.LogInformation("Payment done. Ticket Advisory: {Advisory}", paymentSystem);
                                    //Zappier
                                    var zapierPayload = new
                                    {
                                        pnr,
                                    };

                                    var zapierJson = JsonSerializer.Serialize(zapierPayload);
                                    var response = await _httpClient.PostAsync("https://hooks.zapier.com/hooks/catch/17823706/u2aylj9/",
                                        new StringContent(zapierJson, Encoding.UTF8, "application/json"));

                                }
                                else
                                {
                                    _logger.LogWarning("InquirePNR returned advisory that is not on-hold.");
                                }


                            }
                        }
                        else
                        {

                            _logger.LogWarning("Payment status is not 'paid': {Status}", session.PaymentStatus);

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
                    catch (Exception innerEx)
                    {
                        _logger.LogError(innerEx, "Error while processing 'checkout.session.completed' webhook event.");
                    }
                }
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error occurred while handling Stripe webhook");

            }

        }
    }
}