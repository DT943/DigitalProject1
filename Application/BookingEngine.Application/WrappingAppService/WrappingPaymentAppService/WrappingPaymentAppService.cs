using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BookingEngine.Application.OTAUserAppService;
using BookingEngine.Application.PaymantAppService;
using BookingEngine.Application.PaymantAppService.Dtos;
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

        private readonly IPaymentPNRResultAppService _paymentPNRResultAppService;
        public WrappingPaymentAppService(
          ILogger<PaymentAppService> logger, IPaymentPNRResultAppService paymentPNRResultAppService)
        {
            _logger = logger;
            _paymentPNRResultAppService = paymentPNRResultAppService;
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
                    BaseFareCurrency = null, // Not required unless numeric
                    TotalFareAmount = TryParseFloat(doc.Descendants(ns + "TotalFare").FirstOrDefault()?.Attribute("Amount")?.Value),
                    TotalFareCurrency = null,
                    TotalEquivFareAmount = TryParseFloat(doc.Descendants(ns + "TotalEquivFare").FirstOrDefault()?.Attribute("Amount")?.Value),
                    TotalEquivFareCurrency = null,

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
                
                _logger.LogWarning("PaymentPNR Result {Payment}.", result);

            }
            catch (Exception ex) { 
            
            }


            return new PaymentSystemGetDto
            {
                Status = "success",
                Error = new List<string>(),
                TicketAdvisory = ticketAdvisory 
            };
        }

    }
}
