using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BookingEngine.Application.WrappingAppService.WrappingAirAvailAppService
{
    public class WrappingAirAvailAppService
    {
        private readonly HttpClient _httpClient;
        private readonly string _username;
        private readonly string _password;
        private readonly string _endpoint;

        public WrappingAirAvailAppService(HttpClient httpClient, string endpoint, string username, string password)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _endpoint = endpoint ?? throw new ArgumentNullException(nameof(endpoint));
            _username = username ?? throw new ArgumentNullException(nameof(username));
            _password = password ?? throw new ArgumentNullException(nameof(password));
        }

        public string CreateAirAvailabilityRequestXml(string origin, string destination, string departureDate, string returnDate,
            int numAdults, int numChildren, int numInfants, string cabin, string flightType)
        {
            var flightTypesXml = new StringBuilder();

            if (flightType == "OneWay")
            {
                flightTypesXml.Append($@"
                <ns2:OriginDestinationInformation>
                    <ns2:DepartureDateTime>{departureDate}</ns2:DepartureDateTime>
                    <ns2:OriginLocation LocationCode=""{origin}""/>
                    <ns2:DestinationLocation LocationCode=""{destination}""/>
                    <ns2:TravelPreferences>
                        <ns2:CabinPref PreferLevel=""Preferred"" Cabin=""{cabin}""/>
                    </ns2:TravelPreferences>
                </ns2:OriginDestinationInformation>");
            }
            else if (flightType == "Return")
            {
                flightTypesXml.Append($@"
                <ns2:OriginDestinationInformation>
                    <ns2:DepartureDateTime>{departureDate}</ns2:DepartureDateTime>
                    <ns2:OriginLocation LocationCode=""{origin}""/>
                    <ns2:DestinationLocation LocationCode=""{destination}""/>
                    <ns2:TravelPreferences>
                        <ns2:CabinPref PreferLevel=""Preferred"" Cabin=""{cabin}""/>
                    </ns2:TravelPreferences>
                </ns2:OriginDestinationInformation>
                <ns2:OriginDestinationInformation>
                    <ns2:DepartureDateTime>{returnDate}</ns2:DepartureDateTime>
                    <ns2:OriginLocation LocationCode=""{destination}""/>
                    <ns2:DestinationLocation LocationCode=""{origin}""/>
                    <ns2:TravelPreferences>
                        <ns2:CabinPref PreferLevel=""Preferred"" Cabin=""{cabin}""/>
                    </ns2:TravelPreferences>
                </ns2:OriginDestinationInformation>");
            }

            string xml = $@"<?xml version=""1.0"" encoding=""UTF-8""?>
                                <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/""
                                               xmlns:xsd=""http://www.w3.org/2001/XMLSchema""
                                               xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">
                                  <soap:Header>
                                    <wsse:Security xmlns:wsse=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd"">
                                      <wsse:UsernameToken>
                                        <wsse:Username>{_username}</wsse:Username>
                                        <wsse:Password>{_password}</wsse:Password>
                                      </wsse:UsernameToken>
                                    </wsse:Security>
                                  </soap:Header>
                                  <soap:Body xmlns:ns2=""http://www.opentravel.org/OTA/2003/05"">
                                    <ns2:OTA_AirAvailRQ SequenceNmbr=""1"" Version=""20061.00"">
                                      <ns2:POS>
                                        <ns2:Source>
                                          <ns2:RequestorID ID=""{_username}"" Type=""4""/>
                                          <ns2:BookingChannel Type=""12""/>
                                        </ns2:Source>
                                      </ns2:POS>
                                      {flightTypesXml}
                                      <ns2:TravelerInfoSummary>
                                        <ns2:AirTravelerAvail>
                                          <ns2:PassengerTypeQuantity Code=""ADT"" Quantity=""{numAdults}""/>
                                          <ns2:PassengerTypeQuantity Code=""CHD"" Quantity=""{numChildren}""/>
                                          <ns2:PassengerTypeQuantity Code=""INF"" Quantity=""{numInfants}""/>
                                        </ns2:AirTravelerAvail>
                                      </ns2:TravelerInfoSummary>
                                    </ns2:OTA_AirAvailRQ>
                                  </soap:Body>
                                </soap:Envelope>";

            return xml;
        }

        public async Task<string> CallAirAvailabilityApiAsync(string xmlRequest)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, _endpoint)
            {
                Content = new StringContent(xmlRequest, Encoding.UTF8, "text/xml")
            };

            request.Headers.Add("SOAPAction", "http://www.opentravel.org/OTA/2003/05/OTA_AirAvail");

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        public Dictionary<string, object> ParseTransactionResponse(string xmlData)
        {
            if (string.IsNullOrWhiteSpace(xmlData))
                return new Dictionary<string, object>();

            var doc = XDocument.Parse(xmlData);

            XNamespace soap = "http://schemas.xmlsoap.org/soap/envelope/";
            XNamespace ns1 = "http://www.opentravel.org/OTA/2003/05";

            var errors = doc.Descendants(ns1 + "Error");
            if (errors.Any())
            {
                var errorDetails = new List<Dictionary<string, string>>();
                foreach (var error in errors)
                {
                    errorDetails.Add(new Dictionary<string, string>
                    {
                        { "code", error.Attribute("Code")?.Value ?? "UNKNOWN" },
                        { "message", error.Attribute("ShortText")?.Value ?? "Unknown error" },
                        { "type", error.Attribute("Type")?.Value ?? "ERR" }
                    });
                }

                var transactionId = doc.Descendants(ns1 + "OTA_AirAvailRS").FirstOrDefault()?.Attribute("TransactionIdentifier")?.Value ?? "";

                return new Dictionary<string, object>
                {
                    { "status", "error" },
                    { "errors", errorDetails },
                    { "transaction_id", transactionId }
                };
            }

            var transactionIdSuccess = doc.Descendants(ns1 + "OTA_AirAvailRS").FirstOrDefault()?.Attribute("TransactionIdentifier")?.Value ?? "";

            return new Dictionary<string, object>
            {
                { "status", "success" },
                { "transaction_id", transactionIdSuccess }
            };
        }

        // Parsing full response similar to parse_response in Python
        public List<Dictionary<string, object>> ParseResponse(string xmlData, string flightType, string destinationTrip)
        {
            var results = new List<Dictionary<string, object>>();
            if (string.IsNullOrWhiteSpace(xmlData))
                return results;

            var doc = XDocument.Parse(xmlData);

            XNamespace ns1 = "http://www.opentravel.org/OTA/2003/05";

            var errors = doc.Descendants(ns1 + "Error");
            if (errors.Any())
            {
                var errorDetails = new List<Dictionary<string, string>>();
                foreach (var error in errors)
                {
                    errorDetails.Add(new Dictionary<string, string>
                    {
                        { "code", error.Attribute("Code")?.Value ?? "UNKNOWN" },
                        { "message", error.Attribute("ShortText")?.Value ?? "Unknown error" },
                        { "type", error.Attribute("Type")?.Value ?? "ERR" }
                    });
                }

                var transactionId = doc.Descendants(ns1 + "OTA_AirAvailRS").FirstOrDefault()?.Attribute("TransactionIdentifier")?.Value ?? "";

                results.Add(new Dictionary<string, object>
                {
                    { "status", "error" },
                    { "errors", errorDetails },
                    { "transaction_id", transactionId }
                });
                return results;
            }

            var transactionIdElem = doc.Descendants(ns1 + "OTA_AirAvailRS").FirstOrDefault();
            var transactionIdStr = transactionIdElem?.Attribute("TransactionIdentifier")?.Value ?? "";

            var travelers = new List<Dictionary<string, string>>();
            var fareBreakdowns = doc.Descendants(ns1 + "PTC_FareBreakdown");
            foreach (var ptc in fareBreakdowns)
            {
                var ptcType = ptc.Attribute("PassengerTypeQuantity")?.Value ?? "";
                var refs = ptc.Descendants(ns1 + "TravelerRefNumber");
                foreach (var reference in refs)
                {
                    var rph = reference.Attribute("RPH")?.Value;
                    if (!string.IsNullOrEmpty(rph))
                    {
                        travelers.Add(new Dictionary<string, string> { { "traveler_ref", rph } });
                    }
                }
            }

            var flightInfos = doc.Descendants(ns1 + "OriginDestinationInformation");

            int flightId = 1;

            foreach (var flight in flightInfos)
            {
                bool takeFlight = true;

                var origin = flight.Element(ns1 + "OriginLocation");
                var destination = flight.Element(ns1 + "DestinationLocation");

                var flightData = new Dictionary<string, object>
                {
                    { "flight_id", flightId },
                    { "origin_code", origin?.Attribute("LocationCode")?.Value },
                    { "origin_name", origin?.Value },
                    { "destination_code", destination?.Attribute("LocationCode")?.Value },
                    { "destination_name", destination?.Value },
                    { "departure_time", flight.Element(ns1 + "DepartureDateTime")?.Value ?? "N/A" },
                    { "arrival_time", flight.Element(ns1 + "ArrivalDateTime")?.Value ?? "N/A" },
                    { "segments", new List<Dictionary<string, object>>() }
                };

                flightId++;
                var segments = flight.Descendants(ns1 + "OriginDestinationOption").Descendants(ns1 + "FlightSegment");

                int segmentId = 1;
                string prevSegmentArrivalTime = null;

                foreach (var seg in segments)
                {
                    var segmentData = new Dictionary<string, object>
                    {
                        { "attributes", seg.Attributes().ToDictionary(a => a.Name.LocalName, a => (object)a.Value) },
                        { "departure_airport", new Dictionary<string, object>() },
                        { "arrival_airport", new Dictionary<string, object>() }
                    };

                    var depAirport = seg.Element(ns1 + "DepartureAirport");
                    var arrAirport = seg.Element(ns1 + "ArrivalAirport");

                    if (depAirport != null)
                    {
                        segmentData["departure_airport"] = depAirport.Attributes().ToDictionary(a => a.Name.LocalName, a => (object)a.Value);
                    }
                    if (arrAirport != null)
                    {
                        segmentData["arrival_airport"] = arrAirport.Attributes().ToDictionary(a => a.Name.LocalName, a => (object)a.Value);
                    }

                    string depCode = ((Dictionary<string, object>)segmentData["departure_airport"]).GetValueOrDefault("LocationCode") as string;

                    // Business logic from Python about flights starting from KWI and time difference > 8 hours
                    if (segmentId > 1 && depCode == "KWI")
                    {
                        if (!(flightType == "Return" && destinationTrip == "KWI"))
                        {
                            if (DateTime.TryParse(segmentData["attributes"].ToString(), out DateTime departureTime) &&
                                DateTime.TryParse(prevSegmentArrivalTime, out DateTime arrivalTime))
                            {
                                var diff = departureTime - arrivalTime;
                                if (diff.TotalHours > 8)
                                {
                                    takeFlight = false;
                                    continue;
                                }
                            }
                        }
                    }

                    segmentId++;
                    prevSegmentArrivalTime = seg.Attribute("ArrivalDateTime")?.Value;
                    ((List<Dictionary<string, object>>)flightData["segments"]).Add(segmentData);
                }

                if (takeFlight)
                {
                    results.Add(new Dictionary<string, object>
                    {
                        { "flight_info", flightData },
                        { "travelers", travelers },
                        { "transaction_id", transactionIdStr }
                    });
                }
            }

            return results;
        }
    }
}
