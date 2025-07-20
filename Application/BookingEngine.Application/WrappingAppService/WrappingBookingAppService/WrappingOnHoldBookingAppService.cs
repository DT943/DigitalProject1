using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BookingEngine.Application.OTAUserAppService.Dtos;
using BookingEngine.Application.WrappingAppService.WrappingBookingAppService;
using BookingEngine.Application.WrappingAppService.WrappingBookingAppService.Dtos;
using Microsoft.Extensions.Options;

namespace BookingEngine.Application.Services
{

    public class WrappingOnHoldBookingAppService: IWrappingOnHoldBookingAppService
    {
        private readonly string _endpoint = "https://reservations.flycham.com/webservices/services/AAResWebServices";

        public WrappingOnHoldBookingAppService()
        {
        }

        private async Task<string> CallAirBookApiAsync(string soapXml)
        {
            using var client = new HttpClient();
            var content = new StringContent(soapXml, Encoding.UTF8, "text/xml");
            content.Headers.Add("SOAPAction", "http://www.opentravel.org/OTA/2003/05/OTA_AirAvail");

            var resp = await client.PostAsync(_endpoint, content);
            resp.EnsureSuccessStatusCode();
            return await resp.Content.ReadAsStringAsync();
        }

        private string BuildSoapRequest(BookCreateDto request, string  userName, string encryptedPassword,string code)
        {
            
            var segXmlBuilder = new StringBuilder();
            foreach (var seg in request.Segments)
            {
                string dep = $"{seg.DepartureDate}T{seg.DepartureTime}";
                string arr = $"{seg.ArrivalDate}T{seg.ArrivalTime}";
                segXmlBuilder.Append($@"
                <ns1:OriginDestinationOption>
                  <ns1:FlightSegment ArrivalDateTime=""{arr}"" DepartureDateTime=""{dep}"" FlightNumber=""{seg.FlightNumber}"" RPH=""{seg.RPH}"" JourneyDuration=""{seg.JourneyDuration}"" returnFlag=""false"">
                    <ns1:DepartureAirport LocationCode=""{seg.OriginCode}"" Terminal=""TerminalX""/>
                    <ns1:ArrivalAirport LocationCode=""{seg.DestinationCode}""/>
                  </ns1:FlightSegment>
                </ns1:OriginDestinationOption>");
            }

            var travXmlBuilder = new StringBuilder();
            int count = Math.Min(request.Travelers.Count, request.ContactInfo.Passengers.Count);

            for (int i = 0; i < count; i++)
            {
                var ti = request.ContactInfo.Passengers.ElementAt(i);
                var trav = request.Travelers[i];

                string formattedBOD = ti.BirthDate.ToString("yyyy-MM-dd");
                string? formattedExpireDate = ti.Passport?.ExpireDate?.ToString("yyyy-MM-dd");


                string rph = trav["traveler_ref"];
                travXmlBuilder.Append($@"
                <ns2:AirTraveler BirthDate=""{formattedBOD}"" PassengerTypeCode=""{ti.PassengerTypeCode}"">
                  <ns2:PersonName>
                    <ns2:GivenName>{ti.GivenName}</ns2:GivenName>
                    <ns2:Surname>{ti.Surname}</ns2:Surname>
                    <ns2:NameTitle>{ti.NameTitle}</ns2:NameTitle>
                  </ns2:PersonName>
                  <ns2:Telephone AreaCityCode=""{request.ContactInfo.CountryCode}"" CountryAccessCode=""{request.ContactInfo.CountryCode}"" PhoneNumber=""{request.ContactInfo.PhoneNumber}""/>
                  <ns2:Document DocHolderNationality=""SY""/>
                  <ns2:TravelerRefNumber RPH=""{rph}""/>
                </ns2:AirTraveler>");
            }

            return $@"
                <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" 
                               xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" 
                               xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance""
                               xmlns:wsse=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd"">
                  <soap:Header>
                    <wsse:Security>
                      <wsse:UsernameToken>
                        <wsse:Username>{userName}</wsse:Username>
                        <wsse:Password>{encryptedPassword}</wsse:Password>
                      </wsse:UsernameToken>
                    </wsse:Security>
                  </soap:Header>
                  <soap:Body xmlns:ns1=""http://www.isaaviation.com/thinair/webservices/OTA/Extensions/2003/05"" 
                             xmlns:ns2=""http://www.opentravel.org/OTA/2003/05"">
                    <ns2:OTA_AirBookRQ SequenceNmbr=""1"" TransactionIdentifier=""{request.TransactionId}"" Version=""2006.01"">
                      <ns2:POS>
                        <ns2:Source>
                          <ns2:RequestorID ID=""{userName}"" Type=""4""/>
                          <ns2:BookingChannel Type=""12""/>
                        </ns2:Source>
                      </ns2:POS>
                      <ns2:AirItinerary DirectionInd=""{request.FlightType}"">
                        <ns1:OriginDestinationOptions  xmlns:ns1=""http://www.opentravel.org/OTA/2003/05"">
                          {segXmlBuilder}
                        </ns1:OriginDestinationOptions>
                      </ns2:AirItinerary>
                      <ns2:TravelerInfo>
                        {travXmlBuilder}
                      </ns2:TravelerInfo>
                    </ns2:OTA_AirBookRQ>
                    <ns1:AAAirBookRQExt>
                      <ns1:ContactInfo>
                        <ns1:PersonName>
                          <ns1:Title>{request.ContactInfo.Title}</ns1:Title>
                          <ns1:FirstName>{request.ContactInfo.FirstName}</ns1:FirstName>
                          <ns1:LastName>{request.ContactInfo.LastName}</ns1:LastName>
                        </ns1:PersonName>
                        <ns1:Telephone>
                          <ns1:PhoneNumber>{request.ContactInfo.PhoneNumber}</ns1:PhoneNumber>
                          <ns1:CountryCode>{request.ContactInfo.CountryCode}</ns1:CountryCode>
                          <ns1:AreaCode>{request.ContactInfo.CountryCode}</ns1:AreaCode>
                        </ns1:Telephone>
                        <ns1:Mobile>
                          <ns1:PhoneNumber>{request.ContactInfo.PhoneNumber}</ns1:PhoneNumber>
                          <ns1:CountryCode>{request.ContactInfo.CountryCode}</ns1:CountryCode>
                          <ns1:AreaCode>{request.ContactInfo.CountryCode}</ns1:AreaCode>
                        </ns1:Mobile>
                        <ns1:Email>{request.ContactInfo.Email}</ns1:Email>
                        <ns1:Address>
                        <ns1:CountryName>
                            <ns1:CountryName>{request.ContactInfo.CountryName}</ns1:CountryName>
                            <ns1:CountryCode>{code}</ns1:CountryCode>
                        </ns1:CountryName>
                          <ns1:CityName>city</ns1:CityName>
                        </ns1:Address>
                      </ns1:ContactInfo>
                    </ns1:AAAirBookRQExt>
                  </soap:Body>
                </soap:Envelope>";
        }

        private XDocument ParseResponse(string xmlResponse)
        {
            return XDocument.Parse(xmlResponse);
        }

        private static BookGetDto ToBookingResult(XDocument doc)
        {
            XNamespace ns1 = "http://www.opentravel.org/OTA/2003/05";

            var errs = doc.Descendants(ns1 + "Error")
                .Select(e => new
                {
                    Code = e.Attribute("Code")?.Value,
                    Message = e.Attribute("ShortText")?.Value
                }).ToList();

            if (errs.Any())
            {
                return new BookGetDto
                {
                    Status = "error",
                    Errors = errs.Select(e => $"{e.Code}: {e.Message}").ToList()
                };
            }

            var res = new BookGetDto();
            var pnr = doc.Descendants(ns1 + "BookingReferenceID")
                         .FirstOrDefault()?.Attribute("ID")?.Value;

            res.PNR = pnr;

            res.FlightSegments = doc.Descendants(ns1 + "FlightSegment").Select(seg => new FlightSegment
            {
                FlightNumber = seg.Attribute("FlightNumber")?.Value,
                DepartureDateTime = seg.Attribute("DepartureDateTime")?.Value,
                ArrivalDateTime = seg.Attribute("ArrivalDateTime")?.Value,
                DepartureAirport = seg.Element(ns1 + "DepartureAirport")?.Attribute("LocationCode")?.Value,
                ArrivalAirport = seg.Element(ns1 + "ArrivalAirport")?.Attribute("LocationCode")?.Value,
                Status = seg.Attribute("Status")?.Value
            }).ToList();

            return res;
        }


        public async Task<BookGetDto> OnHoldBookingFlightAsync(BookCreateDto onholdRequest, OTAUserGetDto oTAUser, string code)
        {

            try
            {
                var soapRequest = BuildSoapRequest(onholdRequest, oTAUser.UserName, oTAUser.EncryptedPassword, code);
                var responseXml = await CallAirBookApiAsync(soapRequest);
                var parsedDoc = ParseResponse(responseXml);
                var result = WrappingOnHoldBookingAppService.ToBookingResult(parsedDoc);

                return result;
            }
            catch (Exception ex)
            {
                return new BookGetDto
                {
                    Status = "error",
                    Errors = new List<string> { "Exception: " + ex.Message }
                };
            }
        }
       
        
        /*
        private async Task SendErrorNotificationAsync(string message)
        {
            // Replace this with your email/logging logic
            await Task.Delay(10); // Simulating async work
            Console.WriteLine($"[Async Error Email] {message}");
        }
        */
    }
}