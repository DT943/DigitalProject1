using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingEngine.Application.Services;
using BookingEngine.Application.WrappingAppService.WrappingBookingAppService.Dtos;
using System.Xml.Linq;
using BookingEngine.Domain.Models;
using FluentValidation;
using Stripe;
using BookingEngine.Application.WrappingAppService.WrappingInquirePNRAppService.Dtos;

namespace BookingEngine.Application.WrappingAppService.WrappingInquirePNRAppService
{
    public class WrappingInquirePNRAppService: IWrappingInquirePNRAppService
    {
        private readonly string _endpoint = "https://reservations.flycham.com/webservices/services/AAResWebServices";
        private readonly string _username = "TESTOTADAM";
        private readonly string _password = "Pass@D542";

        public WrappingInquirePNRAppService()
        {
        }

        private async Task<string> CallInquirePNRApiAsync(string soapXml)
        {
            using var client = new HttpClient();
            var content = new StringContent(soapXml, Encoding.UTF8, "text/xml");
            content.Headers.Add("SOAPAction", "http://www.opentravel.org/OTA/2003/05/OTA_AirAvail");

            var resp = await client.PostAsync(_endpoint, content);
            resp.EnsureSuccessStatusCode();
            return await resp.Content.ReadAsStringAsync();
        }

        private string BuildSoapRequest(InquirePNRCreateDto request)
        {

            string formattedDep = request.DepartureDate.ToString("yyyy-MM-dd");

            return $@"
                <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">
                    <soap:Header>
                        <wsse:Security soap:mustUnderstand=""1"" xmlns:wsse=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd"">
                            <wsse:UsernameToken wsu:Id=""UsernameToken-17099451"" xmlns:wsu=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd"">
                                <wsse:Username>{_username}</wsse:Username>
                                <wsse:Password Type=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText"">{_password}</wsse:Password>
                            </wsse:UsernameToken>
                        </wsse:Security>
                    </soap:Header>
                    <soap:Body xmlns:ns1=""http://www.isaaviation.com/thinair/webservices/OTA/Extensions/2003/05"" xmlns:ns2=""http://www.opentravel.org/OTA/2003/05"">
                        <ns2:OTA_ReadRQ EchoToken=""11839640750780-171674061"" PrimaryLangID=""en-us"" SequenceNmbr=""1"" TimeStamp=""2023-02-28T20:00:00"" Version=""20061.00"">
                            <ns2:POS>
                                <ns2:Source TerminalID=""TestUser/Test Runner"">
                                    <ns2:RequestorID ID=""{_username}"" Type=""4""/>
                                    <ns2:BookingChannel Type=""12""/>
                                </ns2:Source>
                            </ns2:POS>
                            <ns2:ReadRequests>
                                <ns2:ReadRequest>
                                    <ns2:UniqueID ID=""{request.PNR}"" Type=""14""/>
                                </ns2:ReadRequest>
                                <ns2:AirReadRequest>
                                    <ns2:DepartureDate>{formattedDep}</ns2:DepartureDate>
                                </ns2:AirReadRequest>
                            </ns2:ReadRequests>
                        </ns2:OTA_ReadRQ>
                        <ns1:AAReadRQExt>
                            <ns1:AALoadDataOptions>
                                <ns1:LoadTravelerInfo>true</ns1:LoadTravelerInfo>
                                <ns1:LoadAirItinery>true</ns1:LoadAirItinery>
                                <ns1:LoadPriceInfoTotals>true</ns1:LoadPriceInfoTotals>
                                <ns1:LoadFullFilment>true</ns1:LoadFullFilment>
                            </ns1:AALoadDataOptions>
                        </ns1:AAReadRQExt>
                    </soap:Body>
                </soap:Envelope>";
        }

        private XDocument ParseResponse(string xmlResponse)
        {
            return XDocument.Parse(xmlResponse);
        }

        private static InquirePNRGetDto ToInquirePNRResult(XDocument doc, string lastname)
        {
            XNamespace ns = "http://www.opentravel.org/OTA/2003/05";
            XNamespace ns2 = "http://www.isaaviation.com/thinair/webservices/OTA/Extensions/2003/05";

            var errors = doc.Descendants(ns + "Error")
                .Select(e => $"{e.Attribute("Code")?.Value}: {e.Attribute("ShortText")?.Value}")
                .ToList();

            if (errors.Any())
            {
                return new InquirePNRGetDto
                {
                    Status = "error",
                    Errors = errors
                };
            }

            var result = new InquirePNRGetDto
            {
                Status = "success",
                Errors = new(),
                Segments = new(),
                Passengers = new()
            };

            var airRes = doc.Descendants(ns + "AirReservation").FirstOrDefault();
            if (airRes == null)
            {
                result.Status = "error";
                result.Errors.Add("Missing AirReservation node");
                return result;
            }
            var matchedPassenger = 0;

            // Passengers
            result.Passengers = airRes.Descendants(ns + "AirTraveler")
                .Select(p =>
                {
                    var lastNamePassenger = p.Element(ns + "PersonName")?.Element(ns + "Surname")?.Value;

                    if (lastNamePassenger == lastname)
                        matchedPassenger += 1;

                    DateTime.TryParse(p.Element(ns + "Document")?.Attribute("ExpireDate")?.Value, out var exp);
                    return new BookPassengerDto
                    {
                        FirstName = p.Element(ns + "PersonName")?.Element(ns + "GivenName")?.Value,
                        LastName = lastNamePassenger,
                        Title = p.Element(ns + "PersonName")?.Element(ns + "NameTitle")?.Value,
                        PassengerType = p.Attribute("PassengerTypeCode")?.Value,
                        PhoneNumber = p.Element(ns + "Telephone")?.Attribute("PhoneNumber")?.Value,
                        DocumentNumber = p.Element(ns + "Document")?.Attribute("DocID")?.Value,
                        DocumentType = p.Element(ns + "Document")?.Attribute("DocType")?.Value,
                        DocumentIssueCountry = p.Element(ns + "Document")?.Attribute("DocIssueCountry")?.Value,
                        Nationality = p.Element(ns + "Document")?.Attribute("DocHolderNationality")?.Value,
                        DocumentExpiry = exp,
                        Rph = p.Element(ns + "TravelerRefNumber")?.Attribute("RPH")?.Value
                    };
                }).ToList();


            // Contact Info
            var contact = doc.Descendants(ns2 + "ContactInfo").FirstOrDefault();
            if (contact != null)
            {
                if (contact.Element(ns2 + "PersonName")?.Element(ns2 + "LastName")?.Value == lastname)
                    matchedPassenger += 1;

                result.ContactInfo = new BookContactInfoDto
                {
                    Title = contact.Element(ns2 + "PersonName")?.Element(ns2 + "Title")?.Value,
                    FirstName = contact.Element(ns2 + "PersonName")?.Element(ns2 + "FirstName")?.Value,
                    LastName = contact.Element(ns2 + "PersonName")?.Element(ns2 + "LastName")?.Value,
                    Telephone = contact.Element(ns2 + "Telephone")?.Element(ns2 + "PhoneNumber")?.Value,
                    Mobile = contact.Element(ns2 + "Mobile")?.Element(ns2 + "PhoneNumber")?.Value,
                    Fax = contact.Element(ns2 + "Fax")?.Element(ns2 + "PhoneNumber")?.Value,
                    Email = contact.Element(ns2 + "Email")?.Value,
                    City = contact.Element(ns2 + "Address")?.Element(ns2 + "CityName")?.Value,
                    CountryCode = contact.Element(ns2 + "Address")?.Element(ns2 + "CountryName")?.Element(ns2 + "CountryCode")?.Value,
                    PreferredLanguage = contact.Element(ns2 + "PreferredLanguage")?.Value
                };
            }
            if (matchedPassenger == 0)
            {
                return new InquirePNRGetDto
                {
                    Status = "error",
                    Errors = errors
                };
            }

            // Passenger Counts
            var ptcs = doc.Descendants(ns2 + "PTCCount").ToList();
            result.PassengerCounts = new BookPassengerCountDto
            {
                Adults = int.Parse(ptcs.FirstOrDefault(p => p.Element(ns2 + "PassengerTypeCode")?.Value == "ADT")?.Element(ns2 + "PassengerTypeQuantity")?.Value ?? "0"),
                Children = int.Parse(ptcs.FirstOrDefault(p => p.Element(ns2 + "PassengerTypeCode")?.Value == "CHD")?.Element(ns2 + "PassengerTypeQuantity")?.Value ?? "0"),
                Infants = int.Parse(ptcs.FirstOrDefault(p => p.Element(ns2 + "PassengerTypeCode")?.Value == "INF")?.Element(ns2 + "PassengerTypeQuantity")?.Value ?? "0")
            };


            // Booking Reference
            result.BookingReference = airRes.Element(ns + "BookingReferenceID")?.Attribute("ID")?.Value;

            // Ticket Info
            var ticket = airRes.Element(ns + "Ticketing");
            if (ticket != null)
            {
                if (DateTime.TryParse(ticket.Attribute("TicketTimeLimit")?.Value, out var ttl))
                    result.TicketTimeLimit = ttl;

                result.TicketAdvisory = ticket.Element(ns + "TicketAdvisory")?.Value;
            }

            // Segments
            result.Segments = airRes.Descendants(ns + "FlightSegment")
                .Select(seg =>
                {
                    DateTime.TryParse(seg.Attribute("DepartureDateTime")?.Value, out var dep);
                    DateTime.TryParse(seg.Attribute("ArrivalDateTime")?.Value, out var arr);
                    return new BookFlightSegmentDto
                    {
                        FlightNumber = seg.Attribute("FlightNumber")?.Value,
                        DepartureAirport = seg.Element(ns + "DepartureAirport")?.Attribute("LocationCode")?.Value,
                        ArrivalAirport = seg.Element(ns + "ArrivalAirport")?.Attribute("LocationCode")?.Value,
                        DepartureTerminal = seg.Element(ns + "DepartureAirport")?.Attribute("Terminal")?.Value,
                        DepartureDateTime = dep,
                        ArrivalDateTime = arr,
                        CabinClass = seg.Attribute("ResCabinClass")?.Value,
                        Rph = seg.Attribute("RPH")?.Value
                    };
                }).ToList();

            // Fare
            var itinFare = airRes.Descendants(ns + "ItinTotalFare").FirstOrDefault();
            if (itinFare != null)
            {
                result.Fare = new BookFareDto
                {
                    BaseFare = decimal.Parse(itinFare.Element(ns + "BaseFare")?.Attribute("Amount")?.Value ?? "0"),
                    Tax = decimal.Parse(itinFare.Descendants(ns + "Tax").FirstOrDefault()?.Attribute("Amount")?.Value ?? "0"),
                    Fee = decimal.Parse(itinFare.Descendants(ns + "Fee").FirstOrDefault()?.Attribute("Amount")?.Value ?? "0"),
                    TotalFareUSD = decimal.Parse(itinFare.Element(ns + "TotalFare")?.Attribute("Amount")?.Value ?? "0"),
                    TotalFareSYP = decimal.Parse(itinFare.Element(ns + "TotalEquivFare")?.Attribute("Amount")?.Value ?? "0"),
                    TotalFareWithCCFeeUSD = decimal.Parse(itinFare.Element(ns + "TotalFareWithCCFee")?.Attribute("Amount")?.Value ?? "0"),
                    TotalFareWithCCFeeSYP = decimal.Parse(itinFare.Element(ns + "TotalEquivFareWithCCFee")?.Attribute("Amount")?.Value ?? "0")
                };
            }

            


            return result;
        }

        public async Task<InquirePNRGetDto> InquirePNRAsync(InquirePNRCreateDto inquirePNRRequest)
        {

            try
            {
                var soapRequest = BuildSoapRequest(inquirePNRRequest);
                var responseXml = await CallInquirePNRApiAsync(soapRequest);
                var parsedDoc = ParseResponse(responseXml);
                var result = WrappingInquirePNRAppService.ToInquirePNRResult(parsedDoc, inquirePNRRequest.LastName);

                return result;
            }
            catch (Exception ex)
            {
                return new InquirePNRGetDto
                {
                    Status = "error",
                    Errors = new List<string> { "Exception: " + ex.Message }
                };
            }
        }

    }

}
