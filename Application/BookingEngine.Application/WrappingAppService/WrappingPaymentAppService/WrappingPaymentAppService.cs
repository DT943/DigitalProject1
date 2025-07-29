using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BookingEngine.Application.AirPortAppService;
using BookingEngine.Application.OTAUserAppService;
using BookingEngine.Application.PaymantAppService;
using BookingEngine.Application.PaymantAppService.Dtos;
using BookingEngine.Application.PDFTicketAppService.Dtos;
using BookingEngine.Application.WrappingAppService.WrappingInquirePNRAppService;
using BookingEngine.Application.WrappingAppService.WrappingInquirePNRAppService.Dtos;
using BookingEngine.Application.WrappingAppService.WrappingPaymentAppService.Dtos;
using BookingEngine.Domain.Models;
using Microsoft.Extensions.Logging;

namespace BookingEngine.Application.WrappingAppService.WrappingPaymentAppService
{
    public class WrappingPaymentAppService : IWrappingPaymentAppService
    {
        private readonly string _endpoint = "https://reservations.flycham.com/webservices/services/AAResWebServicesForPay";
        private readonly ILogger<PaymentAppService> _logger;
        private readonly IAirPortAppService _airPortAppService;


        private readonly IPaymentPNRResultAppService _paymentPNRResultAppService;
        public WrappingPaymentAppService(
          ILogger<PaymentAppService> logger,
          IAirPortAppService airPortAppService,
          IPaymentPNRResultAppService paymentPNRResultAppService)
        {
            _logger = logger;
            _paymentPNRResultAppService = paymentPNRResultAppService;
            _airPortAppService = airPortAppService;
        }

        public async Task<PaymentSystemGetDto> PaymentAsync(PaymentSystemCreateDto request, string sessionId)
        {
            try
            {
                var soapRequest = BuildSoapRequest(request);

                var responseXml = await CallPaymentApiAsync(soapRequest);
                var parsed = XDocument.Parse(responseXml);



                _logger.LogWarning("InquirePNR returned advisory that is not on-hold{parsed}.", parsed);


                return await ParsePaymentResponse(parsed, sessionId);
            }
            catch (Exception ex)
            {
                return new PaymentSystemGetDto
                {
                    Status = "error",
                    Error = new List<string> { "Exception: " + ex.Message }
                };
            }
        }

        private string BuildSoapRequest(PaymentSystemCreateDto request)
        {
            return $@"
                <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/""
	                xmlns:xsd=""http://www.w3.org/2001/XMLSchema""
	                xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">
                    <soap:Header>
                        <wsse:Security soap:mustUnderstand=""1""
			                xmlns:wsse=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd"">
                            <wsse:UsernameToken wsu:Id=""UsernameToken-11632138""
				                xmlns:wsu=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd"">
                                <wsse:Username>{request.UserName}</wsse:Username>
                                <wsse:Password Type=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText"">{request.Password}</wsse:Password>
                            </wsse:UsernameToken>
                        </wsse:Security>
                    </soap:Header>

                    <soap:Body
	                    xmlns:ns1=""http://www.isaaviation.com/thinair/webservices/OTA/Extensions/2003/05""
	                    xmlns:ns2=""http://www.opentravel.org/OTA/2003/05"">
                        <ns2:OTA_AirBookModifyRQ EchoToken=""11839640820153-1743952348"" PrimaryLangID=""en-us"" SequenceNmbr=""1"" TimeStamp=""2023-01-27T13:46:23"" TransactionIdentifier=""{request.TransactionIdentifier}"" Version=""20061.00"">
                            <ns2:POS>
                                <ns2:Source TerminalID=""TestUser/Test Runner"">
                                    <ns2:RequestorID ID=""{request.UserName}"" Type=""4"" />
                                    <ns2:BookingChannel Type=""12"" />
                                </ns2:Source>
                            </ns2:POS>
                            <ns2:AirBookModifyRQ ModificationType=""9"">
                                <ns2:Fulfillment>
                                    <ns2:PaymentDetails>
                                        <ns2:PaymentDetail>
                                            <ns2:DirectBill>
                                                <ns2:CompanyName Code=""{request.CompanyName}""/>
                                            </ns2:DirectBill>
                                            <ns2:PaymentAmount Amount=""{request.Balance}"" CurrencyCode=""USD"" DecimalPlaces=""2"" />
                                        </ns2:PaymentDetail>
                                    </ns2:PaymentDetails>
                                </ns2:Fulfillment>
                                <ns2:BookingReferenceID ID=""{request.PNR}"" Type=""14"" />
                            </ns2:AirBookModifyRQ>
                        </ns2:OTA_AirBookModifyRQ>
                        <ns1:AAAirBookModifyRQExt>
                            <ns1:AALoadDataOptions>
                                <ns1:LoadTravelerInfo>true</ns1:LoadTravelerInfo>
                                <ns1:LoadAirItinery>true</ns1:LoadAirItinery>
                                <ns1:LoadPriceInfoTotals>true</ns1:LoadPriceInfoTotals>
                                <ns1:LoadFullFilment>true</ns1:LoadFullFilment>
                            </ns1:AALoadDataOptions>
                        </ns1:AAAirBookModifyRQExt>
                    </soap:Body>
                </soap:Envelope>";
        }

        private async Task<string> CallPaymentApiAsync(string soapXml)
        {
            using var client = new HttpClient();
            var content = new StringContent(soapXml, Encoding.UTF8, "text/xml");
            content.Headers.Add("SOAPAction", "http://www.opentravel.org/OTA/2003/05/OTA_AirBookModify");

            var resp = await client.PostAsync(_endpoint, content);
            resp.EnsureSuccessStatusCode();
            return await resp.Content.ReadAsStringAsync();
        }


        private float? TryParseFloat(string? input)
        {
            return float.TryParse(input, out var result) ? result : (float?)null;
        }

        private string TryParseFloatToString(string input, string fallback)
        {
            if (float.TryParse(input, out float result))
                return result.ToString("F2");
            return fallback;
        }


        private int? GetPTCCount(XNamespace extNs, XDocument doc, string type)
        {
            return int.TryParse(
                doc.Descendants(extNs + "PTCCount")
                   .Where(x => x.Element(extNs + "PassengerTypeCode")?.Value == type)
                   .Select(x => x.Element(extNs + "PassengerTypeQuantity")?.Value)
                   .FirstOrDefault(),
                out var count
            ) ? count : (int?)null;
        }

        string ParseDateOnly(string dateTime)
        {
            if (DateTime.TryParse(dateTime, out var dt))
                return dt.ToString("yyyy-MM-dd");
            return string.Empty;
        }

        string ParseTimeOnly(string dateTime)
        {
            if (DateTime.TryParse(dateTime, out var dt))
                return dt.ToString("HH:mm");
            return string.Empty;
        }

        private string CalculateDuration(string? departure, string? arrival)
        {
            if (DateTime.TryParse(departure, out var dep) && DateTime.TryParse(arrival, out var arr))
            {
                var duration = arr - dep;
                if (duration.TotalMinutes < 0)
                {
                    // If arrival is before departure (crossing midnight?), add one day
                    duration = duration.Add(TimeSpan.FromDays(1));
                }
                return $"{(int)duration.TotalHours}h {duration.Minutes}m";
            }
            return string.Empty; // fallback if parsing fails
        }

        private async Task<PaymentSystemGetDto> ParsePaymentResponse(XDocument doc,string sessionId)
        {
            XNamespace ns = "http://www.opentravel.org/OTA/2003/05";
            XNamespace extNs = "http://www.isaaviation.com/thinair/webservices/OTA/Extensions/2003/05";


            var errors = doc.Descendants(ns + "Error")
                .Select(e => $"{e.Attribute("Code")?.Value}: {e.Attribute("ShortText")?.Value}")
                .ToList();

            if (errors.Any())
            {
                return new PaymentSystemGetDto
                {
                    Status = "error",
                    Error = errors
                };
            }

            var ticketAdvisory = doc.Descendants(ns + "TicketAdvisory").FirstOrDefault()?.Value;


            try
            {

                var paymentPNRResult = new PaymentPNRResultCreateDto
                {
                    SessionId = sessionId,
                    PNR = doc.Descendants(ns + "BookingReferenceID").FirstOrDefault()?.Attribute("ID")?.Value,
                    TicketAdvisory = doc.Descendants(ns + "TicketAdvisory").FirstOrDefault()?.Value,

                    BaseFareAmount = TryParseFloat(doc.Descendants(ns + "BaseFare").FirstOrDefault()?.Attribute("Amount")?.Value),
                    BaseFareCurrency = TryParseFloat(doc.Descendants(ns + "BaseFare").FirstOrDefault()?.Attribute("CurrencyCode")?.Value),
                    TotalFareAmount = TryParseFloat(doc.Descendants(ns + "TotalFare").FirstOrDefault()?.Attribute("Amount")?.Value),
                    TotalFareCurrency = TryParseFloat(doc.Descendants(ns + "TotalFare").FirstOrDefault()?.Attribute("CurrencyCode")?.Value),
                    TotalEquivFareAmount = TryParseFloat(doc.Descendants(ns + "TotalEquivFare").FirstOrDefault()?.Attribute("Amount")?.Value),
                    TotalEquivFareCurrency = TryParseFloat(doc.Descendants(ns + "TotalEquivFare").FirstOrDefault()?.Attribute("CurrencyCode")?.Value),

                    PaymentAmount = TryParseFloat(doc.Descendants(ns + "PaymentAmount").FirstOrDefault()?.Attribute("Amount")?.Value),
                    PaymentCurrency = doc.Descendants(ns + "PaymentAmount").FirstOrDefault()?.Attribute("CurrencyCode")?.Value,

                    PaymentAmountInPayCurAmount = TryParseFloat(doc.Descendants(ns + "PaymentAmountInPayCur").FirstOrDefault()?.Attribute("Amount")?.Value),
                    PaymentAmountInPayCurCurrency = doc.Descendants(ns + "PaymentAmountInPayCur").FirstOrDefault()?.Attribute("CurrencyCode")?.Value,

                    TicketingStatus = doc.Descendants(ns + "Ticketing").FirstOrDefault()?.Attribute("TicketingStatus")?.Value,
                    TicketType = doc.Descendants(ns + "Ticketing").FirstOrDefault()?.Attribute("TicketType")?.Value,
                    CompanyName = doc.Descendants(ns + "CompanyName").FirstOrDefault()?.Value,

                    NumberOfADT = GetPTCCount(extNs, doc, "ADT"),
                    NumberOfCHD = GetPTCCount(extNs, doc, "CHD"),
                    NumberOfINF = GetPTCCount(extNs, doc, "INF"),

                    Segments = doc.Descendants(ns + "FlightSegment").Select(seg => new PaymentPNRFlightSegmentCreateDto
                    {
                        FlightNumber = seg.Attribute("FlightNumber")?.Value,
                        DepartureAirportCode = seg.Element(ns + "DepartureAirport")?.Attribute("LocationCode")?.Value,
                        ArrivalAirportCode = seg.Element(ns + "ArrivalAirport")?.Attribute("LocationCode")?.Value,
                        DepartureDateTime = seg.Attribute("DepartureDateTime")?.Value,
                        ArrivalDateTime = seg.Attribute("ArrivalDateTime")?.Value,
                        Terminal = seg.Element(ns + "DepartureAirport")?.Attribute("Terminal")?.Value,
                        CabinClass = seg.Attribute("ResCabinClass")?.Value,
                        Status = seg.Attribute("Status")?.Value,
                        RPH = seg.Attribute("RPH")?.Value,
                        Comment = seg.Element(ns + "Comment")?.Value
                    }).ToList(),

                    Passengers = doc.Descendants(ns + "AirTraveler").Select(pax => new PaymentPNRPassengerCreateDto
                    {
                        FirstName = pax.Element(ns + "PersonName")?.Element(ns + "GivenName")?.Value,
                        LastName = pax.Element(ns + "PersonName")?.Element(ns + "Surname")?.Value,
                        Title = pax.Element(ns + "PersonName")?.Element(ns + "NameTitle")?.Value,
                        PhoneNumber = pax.Element(ns + "Telephone")?.Attribute("PhoneNumber")?.Value,
                        Nationality = pax.Element(ns + "Document")?.Attribute("DocHolderNationality")?.Value,
                        TypeCode = pax.Attribute("PassengerTypeCode")?.Value
                    }).ToList(),

                    Taxes = doc.Descendants(ns + "Tax").Select(tax => new PaymentPNRTaxCreateDto
                    {
                        TaxCode = tax.Attribute("TaxCode")?.Value,
                        Amount = TryParseFloat(tax.Attribute("Amount")?.Value),
                        Currency = tax.Attribute("CurrencyCode")?.Value
                    }).ToList(),

                    Fees = doc.Descendants(ns + "Fee").Select(fee => new PaymentPNRFeeCreateDto
                    {
                        FeeCode = fee.Attribute("FeeCode")?.Value,
                        Amount = TryParseFloat(fee.Attribute("Amount")?.Value),
                        Currency = fee.Attribute("CurrencyCode")?.Value
                    }).ToList(),

                    ETickets = doc.Descendants(ns + "ETicketInfomation").Select(et => new PaymentPNRETicketInfoCreateDto
                    {
                        ETicketNumber = et.Attribute("eTicketNo")?.Value,
                        CouponNumber = et.Attribute("couponNo")?.Value,
                        FlightSegmentRPH = et.Attribute("flightSegmentRPH")?.Value,
                        TicketStatus = et.Attribute("status")?.Value,
                        UsedStatus = et.Attribute("usedStatus")?.Value
                    }).ToList(),

                    Contact = new PaymentPNRContactCreateDto
                    {
                        Title = doc.Descendants(extNs + "Title").FirstOrDefault()?.Value,
                        FirstName = doc.Descendants(extNs + "FirstName").FirstOrDefault()?.Value,
                        LastName = doc.Descendants(extNs + "LastName").FirstOrDefault()?.Value,
                        PhoneNumber = doc.Descendants(extNs + "Telephone").FirstOrDefault()?.Element(extNs + "PhoneNumber")?.Value,
                        MobileNumber = doc.Descendants(extNs + "Mobile").FirstOrDefault()?.Element(extNs + "PhoneNumber")?.Value,
                        CountryCode = doc.Descendants(extNs + "Telephone").FirstOrDefault()?.Element(extNs + "CountryCode")?.Value,
                        AreaCode = doc.Descendants(extNs + "Telephone").FirstOrDefault()?.Element(extNs + "AreaCode")?.Value,
                        Email = doc.Descendants(extNs + "Email").FirstOrDefault()?.Value,
                        CityName = doc.Descendants(extNs + "CityName").FirstOrDefault()?.Value,
                        CountryName = doc.Descendants(extNs + "CountryName").Elements(extNs + "CountryName").FirstOrDefault()?.Value,
                        CountryIsoCode = doc.Descendants(extNs + "CountryName").Elements(extNs + "CountryCode").FirstOrDefault()?.Value,
                        PreferredLanguage = doc.Descendants(extNs + "PreferredLanguage").FirstOrDefault()?.Value
                    }

                };

                _logger.LogWarning("PaymentPNR Create input {Payment}.", paymentPNRResult);

                var result = await _paymentPNRResultAppService.Create(paymentPNRResult);


                //  Sum all amounts as decimals (for precision)
                decimal totalAmount = doc.Descendants(ns + "Tax")
                    .Concat(doc.Descendants(ns + "Fee"))
                    .Select(x =>
                    {
                        var amountStr = x.Attribute("Amount")?.Value;
                        // Use decimal.TryParse with InvariantCulture for decimal point parsing
                        return decimal.TryParse(amountStr, NumberStyles.Any, CultureInfo.InvariantCulture, out var val) ? val : 0m;
                    })
                    .Sum();

                

                var ticket = new PDFTicketCreateDto
                {
                    SessionId = sessionId,
                    PNR = doc.Descendants(ns + "BookingReferenceID").FirstOrDefault()?.Attribute("ID")?.Value,
                    DateOfBooking = DateTime.Now.ToString("yyyy-MM-dd"), 

                    PaidAmountUSD = TryParseFloatToString(doc.Descendants(ns + "TotalFare").FirstOrDefault()?.Attribute("Amount")?.Value,"0.00"),
                    ChargesUSD = TryParseFloatToString(totalAmount.ToString(CultureInfo.InvariantCulture), "0.00"),
                    FareUSD = TryParseFloatToString(doc.Descendants(ns + "BaseFare").FirstOrDefault()?.Attribute("Amount")?.Value,"0.00"),
                    BalanceUSD = "0.00", //TryParseFloatToString(doc.Descendants(ns + "PaymentAmount").FirstOrDefault()?.Attribute("Amount")?.Value, "0.00"),

                    ContactFirstName = doc.Descendants(extNs + "FirstName").FirstOrDefault()?.Value ?? string.Empty,
                    ContactLastName = doc.Descendants(extNs + "LastName").FirstOrDefault()?.Value ?? string.Empty,
                    ContactEmail = doc.Descendants(extNs + "Email").FirstOrDefault()?.Value ?? string.Empty,
                    ContactPhone = doc.Descendants(extNs + "Telephone").FirstOrDefault()?.Element(extNs + "PhoneNumber")?.Value ?? string.Empty,
                    ContactAreaCode = doc.Descendants(extNs + "Telephone").FirstOrDefault()?.Element(extNs + "AreaCode")?.Value ?? string.Empty ?? string.Empty,
                    ContactCountryCode = doc.Descendants(extNs + "Telephone").FirstOrDefault()?.Element(extNs + "CountryCode")?.Value ?? string.Empty,

                    FlightSegments = doc.Descendants(ns + "FlightSegment").Select(seg => new FlightSegmentCreateDto
                    {
                        FlightNumber =  seg.Attribute("FlightNumber")?.Value ?? string.Empty,
                        OriginAirPort =  _airPortAppService.GetByIataCode(seg.Element(ns + "DepartureAirport").Attribute("LocationCode").Value.ToString()),

                        //OriginAirPort =seg.Element(ns + "DepartureAirport").Attribute("LocationCode").ToString(),


                        DestinationAirPort = _airPortAppService.GetByIataCode(seg.Element(ns + "ArrivalAirport").Attribute("LocationCode").Value.ToString()),
                        //DestinationAirPort = seg.Element(ns + "ArrivalAirport").Attribute("LocationCode").Value.ToString(),


                        Duration = CalculateDuration(seg.Attribute("DepartureDateTime")?.Value, seg.Attribute("ArrivalDateTime")?.Value),
       
                        Terminal = seg.Element(ns + "ArrivalAirport")?.Attribute("Terminal")?.Value ?? seg.Element(ns + "DepartureAirport")?.Attribute("Terminal")?.Value ?? string.Empty, 
                       
                        Aircraft = "", 

                        DepartureDate = ParseDateOnly(seg.Attribute("DepartureDateTime")?.Value),      
                        ArrivalDate = ParseDateOnly(seg.Attribute("ArrivalDateTime")?.Value),
                        DepartureTime = ParseTimeOnly(seg.Attribute("DepartureDateTime")?.Value),
                        ArrivalTime = ParseTimeOnly(seg.Attribute("ArrivalDateTime")?.Value),


                        FlightClass = seg.Attribute("ResCabinClass")?.Value == "Y" ? "Economy Class" : "Business Class",


                        Status = seg.Attribute("Status")?.Value == "35" ? "OK" : seg.Attribute("Status")?.Value ?? string.Empty,

                        // Assign values
                        CheckInFromDate = DateTime.Parse(seg.Attribute("DepartureDateTime").Value).AddHours(-3).ToString("yyyy-MM-dd"),
                        CheckInFromTime = DateTime.Parse(seg.Attribute("DepartureDateTime").Value).AddHours(-3).ToString("HH:mm"),

                    }).ToList(),

                    PassengerTicketInfos = new List<PassengerTicketInfo>(),
                    FareRules = new List<FareRuleCreateDto>() 
                };

                _logger.LogWarning("Tiket Result {ticket}.", ticket);

                _logger.LogWarning("PaymentPNR Result {Payment}.", result);
                
                return new PaymentSystemGetDto
                {
                    Status = "success",
                    Error = new List<string>(),
                    TicketAdvisory = ticketAdvisory,
                    results = ticket
                };
            }
            catch (Exception ex) { 
             
            }


            return new PaymentSystemGetDto
            {
                Status = "error",
                Error = new List<string>(),
                TicketAdvisory = ticketAdvisory,
            };

        }

    }
}
