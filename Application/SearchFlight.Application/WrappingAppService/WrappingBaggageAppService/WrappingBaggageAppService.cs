using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using System.Linq;

namespace SearchFlight.Application.WrappingAppService
{


    public class GetBaggageService
    {
        private readonly string _endpoint;
        private readonly string _username;
        private readonly string _password;
        private readonly HttpClient _httpClient;

        public GetBaggageService(HttpClient httpClient, string endpoint, string username, string password)
        {
            _httpClient = httpClient;
            _endpoint = endpoint;
            _username = username;
            _password = password;
        }
        /*

        public string CreateBaggageRequest(List<SegmentDto> SegmentDtos, string transactionId)
        {
            var sb = new StringBuilder();

            foreach (var SegmentDto in SegmentDtos)
            {
                var departureDateTime = $"{SegmentDto.DepartureDate}T{SegmentDto.DepartureTime}";
                var arrivalDateTime = $"{SegmentDto.ArrivalDate}T{SegmentDto.ArrivalTime}";

                sb.Append($@"<ns:BaggageDetailsRequest TravelerRefNumberRPHs="">
                        <ns:FlightSegmentDtoInfo ArrivalDateTime="{ arrivalDateTime}
                " DepartureDateTime="{ departureDateTime}
                " FlightNumber="{ SegmentDto.FlightNumber}
                " RPH="{ SegmentDto.Rph}
                " returnFlag="false">
                            < ns:DepartureAirport LocationCode = "{SegmentDto.OriginCode}" Terminal = "Terminal1" />
                            < ns:ArrivalAirport LocationCode = "{SegmentDto.DestinationCode}" Terminal = "TerminalX" />
                            < ns:OperatingAirline Code = "XH" />
                        </ ns:FlightSegmentDtoInfo >
                    </ ns:BaggageDetailsRequest > "
                );
            }

            return $@"<soapenv:Envelope xmlns:ns='http://www.opentravel.org/OTA/2003/05' xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/'>
                <soapenv:Header>
                    <wsse:Security soapenv:mustUnderstand='1' xmlns:wsse='http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd'>
                        <wsse:UsernameToken xmlns:wsu='http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd'>
                            <wsse:Username>{_username}</wsse:Username>
                            <wsse:Password Type='http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText'>{_password}</wsse:Password>
                        </wsse:UsernameToken>
                    </wsse:Security>
                </soapenv:Header>
                <soapenv:Body>
                    <ns:AA_OTA_AirBaggageDetailsRQ EchoToken='token' PrimaryLangID='en-us' SequenceNmbr='1' TransactionIdentifier='{transactionId}' Version='20061.00'>
                        <ns:POS>
                            <ns:Source TerminalID='TestUser/Test Runner'>
                                <ns:RequestorID ID='{_username}' Type='4' />
                                <ns:BookingChannel Type='12' />
                            </ns:Source>
                        </ns:POS>
                        <ns:BaggageDetailsRequests>
                            {sb.ToString()}
                        </ns:BaggageDetailsRequests>
                    </ns:AA_OTA_AirBaggageDetailsRQ>
                </soapenv:Body>
            </soapenv:Envelope>";
        }
        */
        public async Task<string> CallBaggageApiAsync(string xmlRequest)
        {
            var content = new StringContent(xmlRequest, Encoding.UTF8, "text/xml");
            content.Headers.Add("SOAPAction", "http://www.opentravel.org/OTA/2003/05/OTA_AirAvail");

            try
            {
                var response = await _httpClient.PostAsync(_endpoint, content);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"API request failed: {ex.Message}");
                return null;
            }
        }

        public object ParseResponse(string xmlData)
        {
            if (string.IsNullOrEmpty(xmlData))
                return new { status = "error", errors = new[] { new { code = "", message = "Empty response", type = "" } } };

            var xdoc = XDocument.Parse(xmlData);
            XNamespace ns = "http://www.opentravel.org/OTA/2003/05";

            var errors = xdoc.Descendants(ns + "Error").Select(e => new
            {
                code = e.Attribute("Code")?.Value ?? "UNKNOWN",
                message = e.Attribute("ShortText")?.Value ?? "Unknown error",
                type = e.Attribute("Type")?.Value ?? "ERR"
            }).ToList();

            if (errors.Any())
            {
                return new { status = "error", errors = errors };
            }

            var transactionId = xdoc.Descendants(ns + "AA_OTA_AirBaggageDetailsRS").FirstOrDefault()?.Attribute("TransactionIdentifier")?.Value ?? "";
            var baggageCodes = xdoc.Descendants(ns + "Baggage")
                .Select(b => b.Element(ns + "baggageCode")?.Value?.Trim())
                .Where(code => !string.IsNullOrEmpty(code))
                .ToList();

            if (!baggageCodes.Any())
            {
                return new
                {
                    status = "error",
                    errors = new[]
                    {
                        new { code = "", message = "No baggage codes found in response.", type = "" }
                    }
                };
            }

            return new { transaction_id = transactionId, baggage_code = baggageCodes };
        }
    }
}
