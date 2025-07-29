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
using BookingEngine.Data.Migrations;
using BookingEngine.Application.PDFTicketAppService.Dtos;
using BookingEngine.Application.PassengerInfo.Dtos;
using BookingEngine.Application.PDFTicketAppService;
using Microsoft.EntityFrameworkCore;
using BookingEngine.Application.StripeSessionDataAppService;



namespace BookingEngine.Application.PaymantAppService
{
    public class PaymentAppService : IPaymentAppService
    {
        private readonly IStripeResultAppService _stripeResultAppService;
        private readonly IWrappingInquirePNRAppService _wrappingInquirePNRAppService;
        private readonly IOTAUserAppService _oTAUserAppService;
        private IEncryptionAppService _encryptionAppService;
        private readonly HttpClient _httpClient;

        private readonly IPDFTicketAppService _pdfTicketAppService;


        private readonly ILogger<PaymentAppService> _logger;

        private readonly IStripeSessionDataAppService _stripeSessionDataAppService;

        private IWrappingPaymentAppService _wrappingPaymentAppService;

        public PaymentAppService(IStripeResultAppService stripeResultAppService, 
            IWrappingInquirePNRAppService wrappingInquirePNRAppService,
            IOTAUserAppService oTAUserAppService,
            IWrappingPaymentAppService wrappingPaymentAppService,
            ILogger<PaymentAppService> logger,
            HttpClient httpClient,
            IStripeSessionDataAppService stripeSessionDataAppService,
            IEncryptionAppService encryptionAppService,
            IPDFTicketAppService pDFTicketAppService)
        {
            _stripeSessionDataAppService = stripeSessionDataAppService;
            _stripeResultAppService = stripeResultAppService;
            _wrappingInquirePNRAppService = wrappingInquirePNRAppService;
            _oTAUserAppService = oTAUserAppService;
            _encryptionAppService = encryptionAppService;
            _wrappingPaymentAppService = wrappingPaymentAppService;
            _logger = logger;
            _pdfTicketAppService = pDFTicketAppService;

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

        public async Task<string> CreateCheckoutSessionAsync(ICollection<PassengerInfoCreateDto> Passengers, List<Dictionary<string, string>> Travelers, List<PricingInfoDto> PassengerInfo, StripeSettingsDto settings, StripeInfoDto stripeInfo , string pnr, int pos, string paymentAmount)
        {
            StripeConfiguration.ApiKey = settings.SecretKey;




            var multiplier = GetStripeCurrencyMultiplier(stripeInfo.Currency);
            var passengerInfoJson = JsonSerializer.Serialize(PassengerInfo);
            var passengersJson = JsonSerializer.Serialize(Passengers);
            var travelersJson = JsonSerializer.Serialize(Travelers);

            var stripeData = new StripeSessionDataCreateDto
            {
                Pnr = pnr,
                PassengerInfoJson = passengerInfoJson,
                PassengersJson = passengersJson,
                TravelersJson = travelersJson
            };

            var stripedata = await _stripeSessionDataAppService.Create(stripeData);
           

            if (passengerInfoJson.Length > 500)
                passengerInfoJson = passengerInfoJson.Substring(0, 500); 


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
                PhoneNumberCollection = new Stripe.Checkout.SessionPhoneNumberCollectionOptions
                {
                    Enabled = true,

                },
                SuccessUrl = "http://flycham.com/booking-confirm?session_id={CHECKOUT_SESSION_ID}",
                CancelUrl = "http://flycham.com",
                //ExpiresAt = DateTime.UtcNow.AddMinutes(1)
                ExpiresAt = DateTime.UtcNow.AddMinutes(35),
                Metadata = new Dictionary<string, string>
                {
                    { "pnr", pnr },
                    { "pos", pos.ToString() },
                    { "amount" , paymentAmount},
                    { "currency" ,  stripeInfo.Currency},
                    { "stripeamount" , stripeInfo.Amount.ToString() },
                    { "sessioninfo", stripedata.Id.ToString()}
                },
                PaymentIntentData = new SessionPaymentIntentDataOptions
                {
                    Metadata = new Dictionary<string, string>
                    {
                        { "pnr", pnr }
                    }
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

                        var stripeAmount = session.Metadata != null && session.Metadata.ContainsKey("stripeamount")
                            ? session.Metadata["stripeamount"]
                            : "0";

                        var currency = session.Metadata != null && session.Metadata.ContainsKey("currency")
                            ? session.Metadata["currency"]
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
                                    
                                    //Create PDF
                                    var pdfTicket = res.results;

                                    if (session.Metadata != null && session.Metadata.ContainsKey("sessioninfo") )
                                    {
                                        int id = int.Parse(session.Metadata["sessioninfo"]);

                                        var sessioninfo = await _stripeSessionDataAppService.Get(id);

                                        var passengerInfoJson = sessioninfo.PassengerInfoJson;

                                        var passengerDetailsJson = sessioninfo.PassengersJson;

                                        var rphInfoJson = sessioninfo.TravelersJson;

                                        try
                                        {
                                            var options = new JsonSerializerOptions
                                            {
                                                PropertyNameCaseInsensitive = true
                                            };


                                            var travelerRefs = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(rphInfoJson, options);
                                            _logger.LogInformation("Passenger rph: {passengerInfo}",
                                                rphInfoJson
                                                );

                                            var refs = travelerRefs
                                                .Where(d => d.TryGetValue("traveler_ref", out _))
                                                .Select(d => d["traveler_ref"])
                                                .ToList();

                                            // Count by prefix
                                            int numAdults = refs.Count(r => r.StartsWith("A", StringComparison.OrdinalIgnoreCase));
                                            int numChildren = refs.Count(r => r.StartsWith("C", StringComparison.OrdinalIgnoreCase));
                                            int numInfants = refs.Count(r => r.StartsWith("I", StringComparison.OrdinalIgnoreCase));

                                            _logger.LogInformation("Counts → Adults: {Adults}, Children: {Children}, Infants: {Infants}",
                                                numAdults, numChildren, numInfants);


                                            var pricingInfo = JsonSerializer.Deserialize<List<PricingInfoDto>>(passengerInfoJson, options);
                                            _logger.LogInformation("Passenger Info: {passengerInfo}",
                                                passengerInfoJson
                                                );
                                            
                                            PricingInfoDto ClonePricingInfo(PricingInfoDto source)
                                            {
                                                return new PricingInfoDto
                                                {
                                                    PaxType = source.PaxType,
                                                    BaseFare = new List<string>(source.BaseFare),
                                                    TotalTax = source.TotalTax,
                                                    TotalFees = source.TotalFees,
                                                    TotalFare = source.TotalFare,
                                                    Rules = new List<string>(source.Rules),
                                                    FareBasisCodes = new List<string>(source.FareBasisCodes),
                                                    SegmentCode = new List<string>(source.SegmentCode)
                                                };
                                            }

                                            var expandedPricingInfo = new List<PricingInfoDto>();
                                            // Add Adult Pricing (find the original "ADT" object)
                                            var adultInfo = pricingInfo.FirstOrDefault(p => p.PaxType == "ADT");
                                            if (adultInfo != null)
                                            {
                                                for (int i = 0; i < numAdults; i++)
                                                    expandedPricingInfo.Add(ClonePricingInfo(adultInfo));
                                            }

                                            // Add Child Pricing (find the original "CHD" object)
                                            var childInfo = pricingInfo.FirstOrDefault(p => p.PaxType == "CHD");
                                            if (childInfo != null)
                                            {
                                                for (int i = 0; i < numChildren; i++)
                                                    expandedPricingInfo.Add(ClonePricingInfo(childInfo));
                                            }

                                            // Add Infant Pricing (find the original "INF" object)
                                            var infantInfo = pricingInfo.FirstOrDefault(p => p.PaxType == "INF");
                                            if (infantInfo != null)
                                            {
                                                for (int i = 0; i < numInfants; i++)
                                                    expandedPricingInfo.Add(ClonePricingInfo(infantInfo));
                                            }

                                            // Log result
                                            _logger.LogInformation("Expanded Passenger Info: {json}", JsonSerializer.Serialize(expandedPricingInfo, options));


                                            var travelerDetails = JsonSerializer.Deserialize<ICollection<PassengerInfoCreateDto>>(passengerDetailsJson, options);
                                            _logger.LogInformation("Passenger Details: {passengerInfo}",
                                                passengerDetailsJson
                                                );


                                            // Step to add passenger with respect to infant with adult dependency
                                            // Step 0: Map: traveler_ref → index
                                            var travelerRefIndexMap = travelerRefs
                                                .Select((dict, idx) => new { Ref = dict["traveler_ref"], Index = idx })
                                                .ToDictionary(x => x.Ref, x => x.Index);
                                     
                                            // Step 1: Organize passengers by type
                                            var adults = new List<(int Index, PassengerInfoCreateDto Traveler, PricingInfoDto Pricing, string Ref)>();
                                            var children = new List<(int Index, PassengerInfoCreateDto Traveler, PricingInfoDto Pricing, string Ref)>();
                                            var infants = new List<(int Index, PassengerInfoCreateDto Traveler, PricingInfoDto Pricing, string InfantRef, string AdultRef)>();

                                            if (expandedPricingInfo != null && travelerDetails != null)
                                            {
                                                var travelerList = travelerDetails.ToList();
                                                
                                                for (int i = 0; i < expandedPricingInfo.Count && i < travelerList.Count; i++)
                                                {
                                                    var pricing = expandedPricingInfo[i];
                                                    var traveler = travelerList[i];

                                                    var travelerRef = travelerRefs[i]["traveler_ref"];
                                                    var refIndex = travelerRefIndexMap[travelerRef];

                                                    if (pricing.PaxType == "ADT")
                                                        adults.Add((refIndex, traveler, pricing, travelerRef));
                                                    else if (pricing.PaxType == "CHD")
                                                        children.Add((refIndex, traveler, pricing, travelerRef));
                                                    else if (pricing.PaxType == "INF" && travelerRef.StartsWith("I"))
                                                    {
                                                        //// var infantRef = travelerRef;
                                                        ///// string adultRef = adults.Count > 0 ? adults[^1].Ref : null; // Link to last adult seen
                                                        //// if (adultRef != null)
                                                        //// infants.Add((refIndex, traveler, pricing, infantRef, adultRef));
                                                        var infantRef = travelerRef;
                                                        string adultRef = null;

                                                        // Try to extract adult reference from format like "I5/A1"
                                                        if (travelerRef.Contains("/"))
                                                        {
                                                            var parts = travelerRef.Split('/');
                                                            if (parts.Length == 2)
                                                            {
                                                                adultRef = parts[1]; // e.g., "A1"
                                                            }
                                                        }

                                                        if (!string.IsNullOrWhiteSpace(adultRef))
                                                        {
                                                            infants.Add((refIndex, traveler, pricing, infantRef, adultRef));
                                                            _logger.LogInformation("Linked infant {InfantRef} to adultRef {AdultRef}", infantRef, adultRef);
                                                        }
                                                        else
                                                        {
                                                            _logger.LogWarning("Could not extract adultRef from infant travelerRef: {InfantRef}", travelerRef);
                                                        }


                                                    }
                                                }
                                                // Step 2: Sort adults and children
                                                adults.Sort((a, b) => a.Index.CompareTo(b.Index));
                                                children.Sort((a, b) => a.Index.CompareTo(b.Index));


                                                // Step 3: Append adults and children
                                                foreach (var (Index, traveler, pricing, travelerRef) in adults.Concat(children))
                                                {
                                                    var passType = pricing.PaxType == "CHD" ? "Child" : "Adult";

                                                    pdfTicket.PassengerTicketInfos.Add(new PassengerTicketInfo
                                                    {
                                                        PassengerType = passType,
                                                        PassengerTitle = traveler.NameTitle,
                                                        PassengerFirstName = traveler.GivenName,
                                                        PassengerLastName = traveler.Surname,
                                                        PassengerDateOfBirth = traveler.BirthDate.ToString("yyyy-MM-dd"),
                                                        Fare = pricing.BaseFare
                                                            .Select(f => decimal.Parse(f))
                                                            .Sum()
                                                            .ToString("F2"),
                                                        FareCurrency = "USD",
                                                        Charges = (decimal.Parse(pricing.TotalFees) + decimal.Parse(pricing.TotalTax)).ToString("F2"),
                                                        ChargesCurrency = "USD",
                                                        PaidAmount = pricing.TotalFare,
                                                        PaidAmountCurrency = "USD",
                                                        Balance = "0.00",
                                                        BalanceCurrency = "USD"
                                                    });

                                                    // Step 4: Append any infants linked to this adult
                                                    var linkedInfants = infants
                                                        .Where(inf => inf.AdultRef == travelerRef)
                                                        .OrderBy(inf => inf.Index)
                                                        .ToList();

                                                    // Reverse infants if the infant order is not increasing with respect to adult order
                                                    if (linkedInfants.Count > 1 &&
                                                        linkedInfants[0].Index > linkedInfants[^1].Index)
                                                    {
                                                        linkedInfants.Reverse();
                                                    }
                                                    _logger.LogInformation("Infant Mapped", linkedInfants);
                                                    foreach (var infant in linkedInfants)
                                                    {
                                                        pdfTicket.PassengerTicketInfos.Add(new PassengerTicketInfo
                                                        {
                                                            PassengerType = "BABY",
                                                            PassengerTitle = infant.Traveler.NameTitle,
                                                            PassengerFirstName = infant.Traveler.GivenName,
                                                            PassengerLastName = infant.Traveler.Surname,
                                                            PassengerDateOfBirth = infant.Traveler.BirthDate.ToString("yyyy-MM-dd"),
                                                            Fare = infant.Pricing.BaseFare
                                                            .Select(f => decimal.Parse(f))
                                                            .Sum()
                                                            .ToString("F2"),


                                                            FareCurrency = "USD",
                                                            Charges = (decimal.Parse(infant.Pricing.TotalFees) + decimal.Parse(infant.Pricing.TotalTax)).ToString("F2"),
                                                            ChargesCurrency = "USD",
                                                            PaidAmount = infant.Pricing.TotalFare,
                                                            PaidAmountCurrency = "USD",
                                                            Balance = "0.00",
                                                            BalanceCurrency = "USD"
                                                        });
                                                    }
                                                }
                                            }

                                            ////add infant fare to associate adult 
                                            _logger.LogInformation("Start mapping infant fare/charges to adults...");

                                            // Step X: Sum infant prices into their related adult in pdfTicket.PassengerTicketInfos
                                            foreach (var infant in pdfTicket.PassengerTicketInfos.Where(p => p.PassengerType == "BABY").ToList())
                                            {
                                                _logger.LogInformation("Processing infant: {FirstName} {LastName}", infant.PassengerFirstName, infant.PassengerLastName);

                                                // Find the matching infant from the original `infants` list
                                                var matchedInfant = infants.FirstOrDefault(i =>
                                                    string.Equals(i.Traveler.GivenName?.Trim(), infant.PassengerFirstName?.Trim(), StringComparison.OrdinalIgnoreCase) &&
                                                    string.Equals(i.Traveler.Surname?.Trim(), infant.PassengerLastName?.Trim(), StringComparison.OrdinalIgnoreCase));

                                            
                                                // Get the adultRef this infant is linked to
                                                var adultRef = matchedInfant.AdultRef;
                                                _logger.LogInformation("Matched infant to adultRef: {AdultRef}", adultRef);

                                                // Find the corresponding adult in PassengerTicketInfos using travelerRef
                                                var adultTuple = adults.Concat(children).FirstOrDefault(a => a.Ref == adultRef);
                                                if (adultTuple.Traveler == null)
                                                {
                                                    _logger.LogWarning("No matching adult found for adultRef: {AdultRef}", adultRef);
                                                    continue;
                                                }

                                                var relatedAdult = pdfTicket.PassengerTicketInfos.FirstOrDefault(p =>
                                                    string.Equals(p.PassengerFirstName?.Trim(), adultTuple.Traveler.GivenName?.Trim(), StringComparison.OrdinalIgnoreCase) &&
                                                    string.Equals(p.PassengerLastName?.Trim(), adultTuple.Traveler.Surname?.Trim(), StringComparison.OrdinalIgnoreCase) &&
                                                    (p.PassengerType == "Adult"));

                                                if (relatedAdult == null)
                                                {
                                                    _logger.LogWarning("No related adult in PDF list found for: {FirstName} {LastName}", adultTuple.Traveler.GivenName, adultTuple.Traveler.Surname);
                                                    continue;
                                                }

                                                _logger.LogInformation("Found related adult: {FirstName} {LastName}", relatedAdult.PassengerFirstName, relatedAdult.PassengerLastName);

                                                // Safely parse and sum values
                                                if (decimal.TryParse(relatedAdult.Fare, out var adultFare) &&
                                                    decimal.TryParse(relatedAdult.Charges, out var adultCharges) &&
                                                    decimal.TryParse(relatedAdult.PaidAmount, out var adultPaidAmount) &&
                                                    decimal.TryParse(relatedAdult.Balance, out var adultBalance) &&
                                                    decimal.TryParse(infant.Fare, out var infantFare) &&
                                                    decimal.TryParse(infant.Charges, out var infantCharges) &&
                                                    decimal.TryParse(infant.PaidAmount, out var infantPaidAmount) &&
                                                    decimal.TryParse(infant.Balance, out var infantBalance))
                                                {
                                                    relatedAdult.Fare = (adultFare + infantFare).ToString("F2");
                                                    relatedAdult.Charges = (adultCharges + infantCharges).ToString("F2");
                                                    relatedAdult.PaidAmount = (adultPaidAmount + infantPaidAmount).ToString("F2");
                                                    relatedAdult.Balance = (adultBalance + infantBalance).ToString("F2");
                                                }
                                            }
                                            //remove null value
                                            pdfTicket.PassengerTicketInfos = pdfTicket.PassengerTicketInfos
                                                .Where(p => !string.IsNullOrWhiteSpace(p.PassengerFirstName)
                                                            || !string.IsNullOrWhiteSpace(p.PassengerLastName)
                                                            || !string.IsNullOrWhiteSpace(p.PaidAmount))
                                                .ToList();

                                            ////add infant fare to associate adult 

                                            //sort by passenger type
                                            
                                            pdfTicket.PassengerTicketInfos = pdfTicket.PassengerTicketInfos
                                                .OrderBy(p =>
                                                {
                                                    var type = p.PassengerType?.Trim().ToUpperInvariant();
                                                    int typeOrder = type?.StartsWith("A") == true ? 0 :
                                                                    type?.StartsWith("C") == true ? 1 :
                                                                    type?.StartsWith("B") == true ? 2 : 3;

                                                    int numberPart = 9999;
                                                    if (!string.IsNullOrEmpty(type) && type.Length > 1 && int.TryParse(type.Substring(1), out var num))
                                                    {
                                                        numberPart = num;
                                                    }

                                                    return (typeOrder, numberPart);
                                                })
                                                .ToList();

                                          
                                            var fareRules = new List<FareRuleCreateDto>();


                                            for (int i = 0; i < expandedPricingInfo[0].SegmentCode.Count; i++)
                                            {
                                                fareRules.Add(new FareRuleCreateDto
                                                {
                                                    TermsAndConditions = expandedPricingInfo[0].Rules[i],
                                                    FareBasisCode = expandedPricingInfo[0].FareBasisCodes[i],
                                                    Origin_Destination = expandedPricingInfo[0].SegmentCode[i]
                                                });
                                            }
                                            pdfTicket.FareRules = fareRules;



                                            var fileBytes = await _pdfTicketAppService.GenerateFromTemplate(pdfTicket, stripeAmount, currency);


                                            _logger.LogInformation("Appended {count} passengers and fare rules to PDF ticket.",
                                               expandedPricingInfo?.Count ?? 0);
                                            

                                        }
                                        catch (Exception ex)
                                        {
                                            _logger.LogError(ex, "Failed to deserialize PassengerInfo metadata");
                                        }
                                    }
                                    else
                                    {
                                        _logger.LogWarning("No passenger_info found in session metadata.");
                                    }


                                    _logger.LogInformation("Payment response: {Res}", res);
                                    paymentSystem = res.TicketAdvisory;
                                    _logger.LogInformation("Payment done. Ticket Advisory: {Advisory}", paymentSystem);
                                   
                                    
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