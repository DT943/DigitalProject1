using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BookingEngine.Application.WrappingAppService.Dtos;

namespace BookingEngine.Application.WrappingAppService.WrappingAirSSRAppService
{
    

    public class GetSSRService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiEndpoint;
        private readonly string _username;
        private readonly string _password;

        public GetSSRService(HttpClient httpClient, string apiEndpoint, string username = "", string password = "")
        {
            _httpClient = httpClient;
            _apiEndpoint = apiEndpoint;
            _username = username;
            _password = password;
        }

        public string CreateSSRDetailsRequest(IEnumerable<SegmentModel> segments, string transactionId)
        {
            var sbSegments = new StringBuilder();

            foreach (var segment in segments)
            {
                string departureDatetime = $"{segment.departure_date}T{segment.departure_time}";
                string arrivalDatetime = $"{segment.arrival_date}T{segment.arrival_time}";

                sbSegments.Append($@"
                    <ns2:SSRDetailsRequest>
                        <ns2:FlightSegmentInfo ArrivalDateTime=""{arrivalDatetime}"" DepartureDateTime=""{departureDatetime}""
                            FlightNumber=""{segment.FlightNumber}"" RPH=""{segment.rph}"" returnFlag=""false"">
                            <ns2:DepartureAirport LocationCode=""{segment.origin_code}"" Terminal=""Terminal1"" />
                            <ns2:ArrivalAirport LocationCode=""{segment.destination_code}"" Terminal=""TerminalX"" />
                            <ns2:OperatingAirline Code=""XH"" />
                        </ns2:FlightSegmentInfo>
                        <ns2:SSRDetails ServiceType=""INFLIGHT""/>
                    </ns2:SSRDetailsRequest>");
            }

            string soapEnvelope = $@"
                <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/""
                    xmlns:xsd=""http://www.w3.org/2001/XMLSchema""
                    xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">
                    <soap:Header>
                        <wsse:Security xmlns:wsse=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd"" soap:mustUnderstand=""1"">
                            <wsse:UsernameToken xmlns:wsu=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd"" wsu:Id=""UsernameToken-17855236"">
                                <wsse:Username>{_username}</wsse:Username>
                                <wsse:Password Type=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText"">{_password}</wsse:Password>
                            </wsse:UsernameToken>
                        </wsse:Security>
                    </soap:Header>
                    <soap:Body xmlns:ns2=""http://www.opentravel.org/OTA/2003/05"">
                        <ns2:AA_OTA_AirSSRDetailsRQ EchoToken=""ECHO_TOKEN"" PrimaryLangID=""en-us"" SequenceNmbr=""1"" TransactionIdentifier=""{transactionId}"" Version=""2006.01"">
                            <ns2:POS>
                                <ns2:Source TerminalID=""TestUser/Test Runner"">
                                    <ns2:RequestorID ID=""{_username}"" Type=""4""/>
                                    <ns2:BookingChannel Type=""12""/>
                                </ns2:Source>
                            </ns2:POS>
                            <ns2:SSRDetailsRequests>
                                {sbSegments}
                            </ns2:SSRDetailsRequests>
                        </ns2:AA_OTA_AirSSRDetailsRQ>
                    </soap:Body>
                </soap:Envelope>";

            return soapEnvelope;
        }

        public async Task<string> CallSSRApiAsync(string xmlRequest, string jsessionId = null)
        {
            using var requestMessage = new HttpRequestMessage(HttpMethod.Post, _apiEndpoint);
            requestMessage.Content = new StringContent(xmlRequest, Encoding.UTF8, "text/xml");
            requestMessage.Headers.Add("SOAPAction", "getSSRDetails");

            if (!string.IsNullOrEmpty(jsessionId))
            {
                requestMessage.Headers.Add("Cookie", $"JSESSIONID={jsessionId}");
            }

            try
            {
                var response = await _httpClient.SendAsync(requestMessage);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                // Log exception or handle as needed
                Console.WriteLine($"API request failed: {ex.Message}");
                return null;
            }
        }

        public object ParseResponse(string xmlData)
        {
            if (string.IsNullOrEmpty(xmlData))
                return new List<object>();

            var doc = XDocument.Parse(xmlData);

            XNamespace soapNs = "http://schemas.xmlsoap.org/soap/envelope/";
            XNamespace ns1 = "http://www.opentravel.org/OTA/2003/05";

            var errors = doc.Descendants(ns1 + "Errors").Elements(ns1 + "Error");
            if (errors != null && errors.Any())
            {
                var errorDetails = new List<object>();
                foreach (var error in errors)
                {
                    errorDetails.Add(new
                    {
                        code = error.Attribute("Code")?.Value ?? "UNKNOWN",
                        message = error.Attribute("ShortText")?.Value ?? "Unknown error",
                        type = error.Attribute("Type")?.Value ?? "ERR"
                    });
                }
                return new
                {
                    status = "error",
                    errors = errorDetails
                };
            }

            var transactionId = doc.Descendants(ns1 + "AA_OTA_AirSSRDetailsRS")
                                   .Attributes("TransactionIdentifier")
                                   .FirstOrDefault()?.Value ?? "";

            var ssrResponses = doc.Descendants(ns1 + "SSRDetailsResponse");
            var ssrData = new List<object>();

            foreach (var ssrDetail in ssrResponses)
            {
                var flightSegment = ssrDetail.Element(ns1 + "FlightSegmentInfo");
                if (flightSegment == null) continue;

                var departureAirport = flightSegment.Element(ns1 + "DepartureAirport");
                var arrivalAirport = flightSegment.Element(ns1 + "ArrivalAirport");

                var inflightServices = new List<object>();
                foreach (var service in ssrDetail.Elements(ns1 + "InflightService"))
                {
                    inflightServices.Add(new
                    {
                        ssrCode = service.Element(ns1 + "ssrCode")?.Value,
                        ssrName = service.Element(ns1 + "ssrName")?.Value,
                        ssrDescription = service.Element(ns1 + "ssrDescription")?.Value,
                        serviceAmount = service.Element(ns1 + "serviceAmount")?.Value,
                        availableQty = service.Element(ns1 + "availableQty")?.Value,
                    });
                }

                ssrData.Add(new
                {
                    FlightSegmentInfo = new
                    {
                        ArrivalDateTime = (string)flightSegment.Attribute("ArrivalDateTime"),
                        DepartureDateTime = (string)flightSegment.Attribute("DepartureDateTime"),
                        FlightNumber = (string)flightSegment.Attribute("FlightNumber"),
                        RPH = (string)flightSegment.Attribute("RPH"),
                        SegmentCode = (string)flightSegment.Attribute("SegmentCode"),
                        returnFlag = (string)flightSegment.Attribute("returnFlag"),
                        DepartureAirport = departureAirport?.Attributes().ToDictionary(a => a.Name.LocalName, a => a.Value),
                        ArrivalAirport = arrivalAirport?.Attributes().ToDictionary(a => a.Name.LocalName, a => a.Value),
                    },
                    InflightServices = inflightServices
                });
            }

            if (ssrData.Count == 0)
            {
                return new
                {
                    status = "error",
                    errors = new[]
                    {
                        new {
                            code = "",
                            message = "No SSR codes found in response.",
                            type = ""
                        }
                    }
                };
            }

            return new
            {
                transaction_id = transactionId,
                ssr_data = ssrData
            };
        }
    }
}
